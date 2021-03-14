using System;
using System.Collections.Generic;

#nullable disable

namespace CongestionTaxCalculator.Data.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Passages = new HashSet<Passage>();
        }

        public int Id { get; set; }
        public string RegNumber { get; set; }
        public int VehicleTypeId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Passage> Passages { get; set; }
    }
}
