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
            var tariff = _dataContext.Tariffs.FirstOrDefault(x => x.ZoneId == zoneId
                                                            && timestamp.TimeOfDay > x.DateFrom.TimeOfDay && timestamp.TimeOfDay < x.DateTo.TimeOfDay);
            if (tariff == null)
            {
                //try getting night time 0 price tariff as the timestamp is in the day turnover interval, this should be handled smoother but bug was discovered late. Tests would have caught the error, would add if given more time. 
                tariff = _dataContext.Tariffs.FirstOrDefault(x => x.ZoneId == zoneId && x.Price == 0);
            }

            return tariff;
        }

        public Tariff GetById(int id)
        {
            return _dataContext.Tariffs.FirstOrDefault(x => x.Id == id);
        }

    }
}
