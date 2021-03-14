using System;
using System.Collections.Generic;

#nullable disable

namespace CongestionTaxCalculator.Data.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTaxExempt { get; set; }
        

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
