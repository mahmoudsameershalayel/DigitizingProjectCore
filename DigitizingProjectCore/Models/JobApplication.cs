using System.ComponentModel.DataAnnotations.Schema;

namespace DigitizingProjectCore.Models
{
    public class JobApplication : BaseEntity
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string PlaceBirth { get; set; }
        public string Address { get; set; }
        public int MairtalStatuId { get; set; }
        public int ChildrenCount { get; set; }
        public string WifeWork { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Educations { get; set; }
        public string Experiences { get; set; }
        public string Trainings { get; set; }
        public string Preferences { get; set; }
        public string WhyWork { get; set; }
        public string QuestionAnswer { get; set; }
        public bool StillWork { get; set; }
        public string WhyLeaveCurrentJob { get; set; }
        public int LastSalary { get; set; }
        public int ExpectedSalary { get; set; }
        public bool HaveDrivingLiscence { get; set; }
        public int DrivingLiscenceTypeId { get; set; }
        public double Length { get; set; }
        public int Weight { get; set; }
        public bool IsChecked { get; set; }
        public string Comments { get; set; }
        public string Gender { get; set; }
        public string StillWorkQuestion1Answer { get; set; }
        public string StillWorkQuestion2Answer { get; set; }
        public string CV { get; set; }
        public Job Job { get; set; }
        public DrivingLiscenceType DrivingLiscenceType { get; set; }
        public MaritalStatu MaritalStatu { get; set; }
    }
}
