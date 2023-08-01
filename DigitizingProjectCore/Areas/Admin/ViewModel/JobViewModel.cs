using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class JobViewModel
    {
        public int Id { get; set; }
        public string JobTitleAr { get; set; }
        public string JobTitleEn { get; set; }
        public string DetailsEn { get; set; }
        public string DetailsAr { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime Created_At { get; set; }
        public List<JobApplication> JobApplications { get; set; }
        public bool IsActive { get; set; }
    }
}
