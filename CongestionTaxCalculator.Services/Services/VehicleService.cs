using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CongestionTax.Contracts.Dtos;
using CongestionTax.Contracts.Dtos.Register;
using CongestionTax.Contracts.Interfaces.Services;
using CongestionTaxCalculator.Data.Context;
using CongestionTaxCalculator.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Services.Services
{
    public class VehicleService : IVehicleService
    {
        private IDataContext _dataContext;
        private IMapper _mapper;

        public VehicleService(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public List<Vehicle> GetAll()
        {
            return _dataContext.Vehicles.ToList();
        }

        public Vehicle GetById(int vehicleId)
        {
            return _dataContext.Vehicles.FirstOrDefault(x => x.Id == vehicleId);
        }

        public Vehicle GetByRegNumber(string regNr)
        {
            return _dataContext.Vehicles
                .FirstOrDefault(x => x.RegNumber == regNr);
        }

        public VehicleType GetVehicleTypeByName(string vehicleTypeName, int zoneId)
        {
            return _dataContext.VehicleTypes.FirstOrDefault(x => x.Name == vehicleTypeName && _dataContext.VehicleTypeZones.Any(y => y.ZoneId == zoneId));
        }

        public VehicleDto Save(RegisterVehicle vehicle)
        {
            var existingVehicle = GetByRegNumber(vehicle.RegNumber);
            if (existingVehicle == null)
            {
                var vehicleToSave = new Vehicle() { RegNumber = vehicle.RegNumber, VehicleTypeId = vehicle.VehicleTypeId };

                _dataContext.Vehicles.Add(vehicleToSave);
                _dataContext.SaveChanges();

                return _mapper.Map<VehicleDto>(vehicleToSave);
            }

            return _mapper.Map<VehicleDto>(existingVehicle);
        }

        public List<VehicleTypeDto> GetVehicleTypes(int zoneId = 0)
        {
            IQueryable<VehicleType> query;
            if (zoneId > 0)
            {
                query = _dataContext.VehicleTypeZones.Where(x => x.ZoneId == zoneId).Select(x => x.VehicleType);
            }
            else
            {
                query = _dataContext.VehicleTypes;
            }
            
            var dtos = _mapper.Map<List<VehicleTypeDto>>(query.ToList());

            var vehicleTypeZones = _dataContext.VehicleTypeZones.ToList();

            foreach (var dto in dtos)
            {
                dto.ZoneId = vehicleTypeZones.First(x => x.VehicleTypeId == dto.Id).ZoneId;
            }

            return dtos;
        }

        public VehicleType GetVehicleTypeById(int id)
        {
            return _dataContext.VehicleTypes.FirstOrDefault(x => x.Id == id);
        }
    }
}
