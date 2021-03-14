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
    public class PassagesController : ControllerBase
    {
        private readonly ILogger<PassagesController> _logger;
        private IPassageService _passageService;
        private IVehicleService _vehicleService;

        public PassagesController(ILogger<PassagesController> logger, IPassageService passageService, IVehicleService vehicleService)
        {
            _logger = logger;
            _passageService = passageService;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IEnumerable<PassageDto> Get(string regNumber)
        {
            return _passageService.GetByRegNumber(regNumber);
        }

        [HttpPost]
        public PassageDto RegisterPassage(RegisterPassage registerPassage)
        {
            return _passageService.Save(registerPassage);
        }
    }
}
