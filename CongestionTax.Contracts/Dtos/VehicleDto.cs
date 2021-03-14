using System;
using System.Collections.Generic;
using System.Text;

namespace CongestionTax.Contracts.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
