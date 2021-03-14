using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CongestionTax.Contracts.Interfaces.Services;
using CongestionTaxCalculator.Data.Context;
using CongestionTaxCalculator.Data.Models;

namespace CongestionTaxCalculator.Services.Services
{
    public class TariffService : ITariffService
    {
        private IDataContext _dataContext;

        public TariffService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public Tariff GetTariff(DateTime timestamp, int zoneId)
        {
            return _dataContext.Tariffs.FirstOrDefault(x => x.ZoneId == zoneId
                                                            && timestamp.TimeOfDay > x.DateFrom.TimeOfDay && timestamp.TimeOfDay < x.DateTo.TimeOfDay);
        }

        public Tariff GetById(int id)
        {
            return _dataContext.Tariffs.FirstOrDefault(x => x.Id == id);
        }

    }
}
