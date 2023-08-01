namespace DigitizingProjectCore.Models
{
    public class DrivingLiscenceType
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public List<JobApplication> jobApplications { get; set; }
    }
}
