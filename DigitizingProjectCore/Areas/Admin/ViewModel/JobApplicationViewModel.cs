namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class JobApplicationViewModel
    {
        public int Id { get; set; }
        public string JobTitleEn { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsChecked { get; set; }
        public bool StillWork { get; set; }
        public bool HaveDrivingLiscence { get; set; }
        public DateTime Created_At { get; set; }

    }
}
