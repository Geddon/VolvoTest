using System;
using System.Collections.Generic;

#nullable disable

namespace CongestionTaxCalculator.Data.Models
{
    public partial class Passage
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int TariffId { get; set; }
        public int ZoneId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool ZeroCost { get; set; }
        public bool StartOfPaymentPeriod { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Zone Zone { get; set; }

        public virtual Tariff Tariff { get; set; }
    }
}
