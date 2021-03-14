#nullable disable

namespace CongestionTax.Contracts.Dtos
{
    public class ZoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool SingleChargeRule { get; set; }
    }
}
