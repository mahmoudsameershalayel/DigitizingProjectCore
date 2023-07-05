namespace DigitizingProjectCore.Models
{
    public class City : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public List<Distributor> _Distributors { get; set; }
    }
}
