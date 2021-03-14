using System;
using System.Collections.Generic;

#nullable disable

namespace CongestionTaxCalculator.Data.Models
{
    public partial class TaxFreeDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public bool RecurringWeekly { get; set; }
        public int ZoneId { get; set; }

        public virtual Zone Zone { get; set; }
    }
}
