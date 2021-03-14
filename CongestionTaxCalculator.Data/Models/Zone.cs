using System;
using System.Collections.Generic;

#nullable disable

namespace CongestionTaxCalculator.Data.Models
{
    public partial class Zone
    {
        public Zone()
        {
            Passages = new HashSet<Passage>();
            Tariffs = new HashSet<Tariff>();
            TaxFreeDays = new HashSet<TaxFreeDay>();
            TaxFreePeriods = new HashSet<TaxFreePeriod>();
           // VehicleTypeZones = new HashSet<VehicleTypeZone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool SingleChargeRule { get; set; }

        public virtual ICollection<Passage> Passages { get; set; }
        public virtual ICollection<Tariff> Tariffs { get; set; }
        public virtual ICollection<TaxFreeDay> TaxFreeDays { get; set; }
        public virtual ICollection<TaxFreePeriod> TaxFreePeriods { get; set; }
    }
}
