using System.Collections.Generic;
using CongestionTax.Contracts.Dtos;
using CongestionTaxCalculator.Data.Models;

namespace CongestionTax.Contracts.Interfaces.Services
{
    public interface IZoneService
    {
        List<Zone> GetAll();
        Zone GetById(int zoneId);
        List<ZoneDto> GetDtos(int zoneId = 0);
    }
}