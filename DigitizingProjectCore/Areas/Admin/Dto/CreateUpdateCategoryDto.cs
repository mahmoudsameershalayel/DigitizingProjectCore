namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateCategoryDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsActive { get; set; }
        public int? SortId { get; set; }
    }
}
