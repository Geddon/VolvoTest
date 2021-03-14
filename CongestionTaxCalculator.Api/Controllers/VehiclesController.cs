using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongestionTax.Contracts.Dtos;
using CongestionTax.Contracts.Dtos.Register;
using CongestionTax.Contracts.Interfaces.Services;
using CongestionTaxCalculator.Data.Models;
using CongestionTaxCalculator.Services.Services;

namespace CongestionTaxCalculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;
        private IVehicleService _vehicleService;

        public VehiclesController(ILogger<VehiclesController> logger, IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public VehicleDto RegisterVehicle(RegisterVehicle registerVehicle)
        {
            return _vehicleService.Save(registerVehicle);
        }
    }
}
