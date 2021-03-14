using System;

namespace CongestionTax.Contracts.Dtos
{
    public class PassageDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int TariffId { get; set; }
        public int ZoneId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool ZeroCost { get; set; }
        public bool StartOfPaymentPeriod { get; set; }
        public int Price { get; set; }
    }
}
