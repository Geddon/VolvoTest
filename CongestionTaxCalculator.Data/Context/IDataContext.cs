using CongestionTaxCalculator.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Data.Context
{
    public interface IDataContext
    {
        DbSet<Passage> Passages { get; set; }
        DbSet<Tariff> Tariffs { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<VehicleType> VehicleTypes { get; set; }
        DbSet<VehicleTypeZone> VehicleTypeZones { get; set; }
        DbSet<Zone> Zones { get; set; }
        DbSet<TaxFreeDay> TaxFreeDays { get; set; }
        DbSet<TaxFreePeriod> TaxFreePeriods { get; set; }
        int SaveChanges();
    }
}