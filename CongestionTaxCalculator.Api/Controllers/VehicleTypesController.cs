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
    public class VehicleTypesController : ControllerBase
    {
        private readonly ILogger<VehicleTypesController> _logger;
        private IVehicleService _vehicleService;

        public VehicleTypesController(ILogger<VehicleTypesController> logger, IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IEnumerable<VehicleTypeDto> Get(int zoneId = 0)
        {

            return _vehicleService.GetVehicleTypes(zoneId);
        }
    }
}
