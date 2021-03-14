using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CongestionTaxCalculator.Data.Context;
using CongestionTaxCalculator.Data.Models;
using Microsoft.EntityFrameworkCore.Update;

namespace CongestionTaxCalculator.Services.Services
{
    public class TaxService : ITaxService
    {
        private IDataContext _dataContext;

        public TaxService(IDataContext dataContext)
        {
            _dataContext = dataContext;
            //_tariffService = tariffService;
            //_vehicleService = vehicleService;
            //_zoneService = zoneService;
            //_passageService = passageService;
        }
        
        //public int GetTariffForPassage(DateTime timestamp, string regNumber, int zoneId)
        //{
        //    var vehicle = _vehicleService.GetByRegNumber(regNumber);

        //    var vehicleType = vehicle.VehicleType;
            
        //    if (vehicleType.IsTaxExempt || TimestampIsTollFree(timestamp, zoneId))
        //    {
        //        return 0;
        //    }

        //    var cost = GetCost(timestamp, vehicle.Id, zoneId);
            
        //    return cost;
        //}
        
        //private int GetCost(DateTime timestamp, int vehicleId, int zoneId)
        //{
        //    var zone = _zoneService.GetById(zoneId);
        //    var tariff = _tariffService.GetTariff(timestamp, zoneId);

        //    if (zone.SingleChargeRule)
        //    {
        //        var passagesForVehicle = _passageService.GetByRegNumber(vehicleId);

        //        var paymentPeriodStart = passagesForVehicle.FirstOrDefault(x => 
        //            x.TimeStamp > timestamp.AddMinutes(-60) && x.StartOfPaymentPeriod);

        //        if (paymentPeriodStart != null)
        //        {
        //            var maxPriceInPeriod = passagesForVehicle.Select(x => x.Tariff.Price).Max();

        //            return tariff.Price > maxPriceInPeriod ? tariff.Price : maxPriceInPeriod;
        //        }
        //    }

        //    return tariff.Price;
        //}

        
    }

    public interface ITaxService
    {
        //int GetTariffForPassage(DateTime timestamp, string vehicleTypeName, int zoneId);
        //bool TimestampIsTollFree(DateTime date, int zoneId);
    }
}
