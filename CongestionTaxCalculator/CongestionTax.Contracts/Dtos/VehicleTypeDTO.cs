namespace CongestionTax.Contracts.Dtos
{
    public class VehicleTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTaxExempt { get; set; }
        public int ZoneId { get; set; }
    }
}
