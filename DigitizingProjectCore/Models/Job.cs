namespace DigitizingProjectCore.Models
{
    public class Job : BaseEntity
    {
        public int Id { get; set; }
        public string JobTitleAr { get; set; }
        public string JobTitleEn { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<JobApplication> jobApplications { get; set; }
    }
}
