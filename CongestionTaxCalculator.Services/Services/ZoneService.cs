using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CongestionTax.Contracts.Dtos;
using CongestionTax.Contracts.Interfaces.Services;
using CongestionTaxCalculator.Data.Context;
using CongestionTaxCalculator.Data.Models;

namespace CongestionTaxCalculator.Services.Services
{
    public class ZoneService : IZoneService
    {
        private IDataContext _dataContext;
        private IMapper _mapper;

        public ZoneService(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public List<Zone> GetAll()
        {
            return _dataContext.Zones.ToList();
        }
        public Zone GetById(int zoneId)
        {
            return _dataContext.Zones.FirstOrDefault(x => x.Id == zoneId);
        }
        
        public List<ZoneDto> GetDtos(int zoneId = 0)
        {
            if(zoneId > 0)
            {
                return new List<ZoneDto>
                {
                    _mapper.Map<ZoneDto>(GetById(zoneId))
                };
            }
            return _mapper.Map<List<ZoneDto>>(_dataContext.Zones.ToList());
        }
    }
}
