using System.Collections.Generic;
using CongestionTax.Contracts.Dtos;
using CongestionTax.Contracts.Dtos.Register;
using CongestionTaxCalculator.Data.Models;

namespace CongestionTax.Contracts.Interfaces.Services
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        VehicleDto Save(RegisterVehicle vehicle);
        Vehicle GetById(int vehicleId);
        Vehicle GetByRegNumber(string regNr);
        List<VehicleTypeDto> GetVehicleTypes(int zoneId = 0);
        VehicleType GetVehicleTypeById(int id);
        
        VehicleType GetVehicleTypeByName(string vehicleTypeName, int zoneId);
        
    }
}