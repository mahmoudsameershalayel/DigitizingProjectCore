namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateJobDto
    {
        public int Id { get; set; }
        public string JobTitleAr { get; set; }
        public string JobTitleEn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public bool IsActive { get; set; }
    }
}
