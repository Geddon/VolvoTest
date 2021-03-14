using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongestionTax.Contracts.Dtos;
using CongestionTax.Contracts.Interfaces.Services;
using CongestionTaxCalculator.Data.Models;
using CongestionTaxCalculator.Services.Services;

namespace CongestionTaxCalculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZonesController : ControllerBase
    {
        private readonly ILogger<ZonesController> _logger;
        private IZoneService _zoneService;

        public ZonesController(ILogger<ZonesController> logger, IZoneService zoneService)
        {
            _logger = logger;
            _zoneService = zoneService;
        }

        [HttpGet]
        public IEnumerable<ZoneDto> Get(int zoneId = 0)
        {
            return _zoneService.GetDtos(zoneId);
        }
    }
}
