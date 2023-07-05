namespace DigitizingProjectCore.Models
{
    public class Distributor : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }
        public string Phone { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
    }
}
