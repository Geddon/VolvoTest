using System;
using System.Collections.Generic;

#nullable disable

namespace CongestionTaxCalculator.Data.Models
{
    public partial class Tariff
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ZoneId { get; set; }
        public int Price { get; set; }

        public virtual Zone Zone { get; set; }

        public virtual ICollection<Passage> Passages { get; set; }
    }
}
