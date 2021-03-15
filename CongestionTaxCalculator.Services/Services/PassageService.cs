using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CongestionTax.Contracts.Dtos;
using CongestionTax.Contracts.Dtos.Register;
using CongestionTax.Contracts.Interfaces.Services;
using CongestionTaxCalculator.Data.Context;
using CongestionTaxCalculator.Data.Models;

namespace CongestionTaxCalculator.Services.Services
{
    public class PassageService : IPassageService
    {
        private IDataContext _dataContext;
        private ITaxService _taxService;
        private IVehicleService _vehicleService;
        private ITariffService _tariffService;
        private IZoneService _zoneService;
        private IMapper _mapper;

        public PassageService(IDataContext dataContext,
            ITaxService taxService,
            IVehicleService vehicleService,
            ITariffService tariffService, IZoneService zoneService, IMapper mapper)
        {
            _dataContext = dataContext;
            _taxService = taxService;
            _vehicleService = vehicleService;
            _tariffService = tariffService;
            _zoneService = zoneService;
            _mapper = mapper;
        }

        public PassageDto Save(RegisterPassage registerPassage)
        {
            var timestamp = DateTime.Now;
            var vehicle = _vehicleService.GetByRegNumber(registerPassage.RegNumber);
            var zone = _zoneService.GetById(registerPassage.ZoneId);

            var passage = CreatePassage(timestamp, vehicle.RegNumber, registerPassage.ZoneId);

            if (!passage.ZeroCost && zone.SingleChargeRule)
            {
                if (IsPassageStartOfPaymentPeriod(timestamp, vehicle.Id, zone.Id))
                {
                    passage.StartOfPaymentPeriod = true;
                }
                else
                {
                    UpdatePaymentPeriod(passage);
                }
            }

            _dataContext.Passages.Add(passage);
            _dataContext.SaveChanges();

            return _mapper.Map<PassageDto>(passage);
        }

        public List<PassageDto> GetByRegNumber(string regNumber)
        {
            return _mapper.Map<List<PassageDto>>(_dataContext.Passages.Where(x => x.Vehicle.RegNumber == regNumber).ToList());
        }

        public List<Passage> GetByVehicleId(int vehicleId)
        {
            return _dataContext.Passages.Where(x => x.VehicleId == vehicleId).ToList();
        }

        public Passage CreatePassage(DateTime timestamp, string regNumber, int zoneId)
        {
            var vehicle = _vehicleService.GetByRegNumber(regNumber);
            var vehicleType = vehicle.VehicleType;
            var tariff = _tariffService.GetTariff(timestamp, zoneId);

            var isZeroCost = vehicleType.IsTaxExempt || TimestampIsTollFree(timestamp, zoneId) || MaximumTollAmountReached(vehicle.Id, timestamp);

            return new Passage()
            {
                ZoneId = zoneId,
                TariffId = tariff.Id,
                TimeStamp = timestamp,
                VehicleId = vehicle.Id,
                ZeroCost = isZeroCost
            };
        }

        private bool MaximumTollAmountReached(int vehicleId, DateTime timestamp)
        {
            var passagesTodayWithActiveCost = GetByVehicleId(vehicleId).Where(x => x.TimeStamp.DayOfYear == timestamp.DayOfYear
                && x.TimeStamp.Year == timestamp.Year
                && !x.ZeroCost);

            //60 is a magic number (shame on me), should be represented in the rule settings in DB but ran out of time 
            if (passagesTodayWithActiveCost.Sum(x => x.Tariff.Price) >= 60)
            {
                return true;
            }

            return false;
        }

        private void UpdatePaymentPeriod(Passage passage)
        {
            var costingPassagesLastHour = GetByVehicleId(passage.VehicleId).Where(x => x.TimeStamp > passage.TimeStamp.AddMinutes(-60) && !x.ZeroCost || x.StartOfPaymentPeriod).ToList();

            var paymentPeriodStartPassage = costingPassagesLastHour.FirstOrDefault(x => x.StartOfPaymentPeriod);

            if (paymentPeriodStartPassage != null)
            {
                var passagesInCurrentPeriod =
                    costingPassagesLastHour.Where(x => x.TimeStamp >= paymentPeriodStartPassage.TimeStamp).ToList();

                var tariff = _tariffService.GetById(passage.TariffId);

                var passageWithHigherPrice =
                    passagesInCurrentPeriod.FirstOrDefault(x => x.Tariff.Price >= tariff.Price);

                if (passageWithHigherPrice == null)
                {
                    foreach (var pas in passagesInCurrentPeriod)
                    {
                        pas.ZeroCost = true;
                        _dataContext.Passages.Update(paymentPeriodStartPassage);
                    }
                }
                else
                {
                    passage.ZeroCost = true;
                    _dataContext.Passages.Update(passage);
                }
            }
        }

        private bool IsPassageStartOfPaymentPeriod(DateTime timestamp, int vehicleId, int zoneId)
        {
            var zone = _zoneService.GetById(zoneId);

            if (zone.SingleChargeRule)
            {
                var passagesForVehicleLastHour = GetByVehicleId(vehicleId).Where(x => x.TimeStamp > timestamp.AddMinutes(-60)).ToList();

                var paymentPeriodStart = passagesForVehicleLastHour.FirstOrDefault(x => x.StartOfPaymentPeriod);

                if (paymentPeriodStart == null)
                {
                    return true;
                }
            }

            return false;
        }

        private bool TimestampIsTollFree(DateTime date, int zoneId)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            var taxFreeDays = GetTaxFreeDays(zoneId);
            var taxFreePeriods = GetTaxFreePeriods(zoneId);

            foreach (var period in taxFreePeriods)
            {
                if (period.RecurringYearly)
                {
                    var start = new DateTime(year, period.PeriodStart.Month, period.PeriodStart.Day);
                    var end = new DateTime(year, period.PeriodEnd.Month, period.PeriodEnd.Day);
                    var compare = new DateTime(year, month, day);

                    if (compare >= start && compare <= end)
                    {
                        return true;
                    }
                }
                if (date >= period.PeriodStart && date <= period.PeriodEnd)
                {
                    return true;
                }
            }

            if (taxFreeDays.Any(x =>
                (date.Date == x.Date) ||
                (date.DayOfWeek == x.Date.DayOfWeek && x.RecurringWeekly)))
            {
                return true;
            }

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }

        private List<TaxFreePeriod> GetTaxFreePeriods(int zoneId)
        {
            return _dataContext.TaxFreePeriods.Where(x => x.ZoneId == zoneId).ToList();
        }

        private List<TaxFreeDay> GetTaxFreeDays(int zoneId)
        {
            return _dataContext.TaxFreeDays.Where(x => x.ZoneId == zoneId).ToList();
        }
    }
}
