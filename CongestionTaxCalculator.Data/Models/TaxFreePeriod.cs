using System;
using System.Collections.Generic;

#nullable disable

namespace CongestionTaxCalculator.Data.Models
{
    public partial class TaxFreePeriod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public bool RecurringYearly { get; set; }
        public int ZoneId { get; set; }

        public virtual Zone Zone { get; set; }
    }
}
