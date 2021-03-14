using System;
using CongestionTaxCalculator.Data.Models;

namespace CongestionTax.Contracts.Interfaces.Services
{
    public interface ITariffService
    {
        Tariff GetTariff(DateTime registerPassage, int zoneId);
        Tariff GetById(int id);
    }
}