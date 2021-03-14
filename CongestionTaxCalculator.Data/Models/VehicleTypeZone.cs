using System;
using System.Collections.Generic;

#nullable disable

namespace CongestionTaxCalculator.Data.Models
{
    public partial class VehicleTypeZone
    {
        public int VehicleTypeId { get; set; }
        public int ZoneId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
