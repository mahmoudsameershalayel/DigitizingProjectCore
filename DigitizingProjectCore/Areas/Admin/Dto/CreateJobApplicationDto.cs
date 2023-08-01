using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateJobApplicationDto
    {
        public int Id { get; set; }
        public string IdNo { get; set; }
        public int JobId { get; set; }
        public int MairtalStatuId { get; set; }
        public int DrivingLiscenceTypeId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string PlaceBirth { get; set; }
        public string Address { get; set; }
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
        public double Length { get; set; }
        public int Weight { get; set; }
        public bool IsChecked { get; set; }
        public string Comments { get; set; }
        public string Gender { get; set; }
        public string StillWorkQuestion1Answer { get; set; }
        public string StillWorkQuestion2Answer { get; set; }
        public string CV { get; set; }
        public Job Job { get; set; }

    }
    public class AddJobApplicationWithJMD : CreateJobApplicationDto
    {
        public IEnumerable<SelectListItem> _JobsEn { get; set; }
        public IEnumerable<SelectListItem> _JobsAr { get; set; }
        public IEnumerable<SelectListItem> _MartialStatusEn { get; set; }
        public IEnumerable<SelectListItem> _MartialStatusAr { get; set; }
        public IEnumerable<SelectListItem> _DrivingLiscenceEn { get; set; }
        public IEnumerable<SelectListItem> _DrivingLiscenceAr { get; set; }

        public void InjectJobsEn(List<Job> jobs)
        {
            List<SelectListItem> ListOfJobs = new List<SelectListItem>();
            ListOfJobs.Add(
               new SelectListItem { Text = "Select Job", Value = null }
               );
            foreach (var job in jobs)
            {
                ListOfJobs.Add(
                new SelectListItem { Text = job.JobTitleEn, Value = job.Id.ToString() }
                );
            }
            _JobsEn = ListOfJobs;
        }
        public void InjectJobsAr(List<Job> jobs)
        {
            List<SelectListItem> ListOfJobs = new List<SelectListItem>();
            ListOfJobs.Add(
               new SelectListItem { Text = "Select Job", Value = null }
               );
            foreach (var job in jobs)
            {
                ListOfJobs.Add(
                new SelectListItem { Text = job.JobTitleAr, Value = job.Id.ToString() }
                );
            }
            _JobsAr = ListOfJobs;
        }

        public void InjectMaritalStatusEn(List<MaritalStatu> maritalStatus)
        {
            List<SelectListItem> ListOfMaritalStatus = new List<SelectListItem>();
            ListOfMaritalStatus.Add(
               new SelectListItem { Text = "Select Job", Value = null }
               );
            foreach (var ms in maritalStatus)
            {
                ListOfMaritalStatus.Add(
                new SelectListItem { Text = ms.NameEn , Value = ms.Id.ToString() }
                );
            }
            _MartialStatusEn = ListOfMaritalStatus;
        }
        public void InjectMaritalStatusAr(List<MaritalStatu> maritalStatus)
        {
            List<SelectListItem> ListOfMaritalStatus = new List<SelectListItem>();
            ListOfMaritalStatus.Add(
               new SelectListItem { Text = "Select Job", Value = null }
               );
            foreach (var ms in maritalStatus)
            {
                ListOfMaritalStatus.Add(
                new SelectListItem { Text = ms.NameAr, Value = ms.Id.ToString() }
                );
            }
            _MartialStatusAr = ListOfMaritalStatus;
        }
        public void InjectDrivingLiscenceEn(List<DrivingLiscenceType> types)
        {
            List<SelectListItem> ListOfDrivingLiscence = new List<SelectListItem>();
            ListOfDrivingLiscence.Add(
               new SelectListItem { Text = "Select Job", Value = null }
               );
            foreach (var type in types)
            {
                ListOfDrivingLiscence.Add(
                new SelectListItem { Text = type.NameEn, Value = type.Id.ToString() }
                );
            }
            _DrivingLiscenceEn = ListOfDrivingLiscence;
        }
        public void InjectDrivingLiscenceAr(List<DrivingLiscenceType> types)
        {
            List<SelectListItem> ListOfDrivingLiscence = new List<SelectListItem>();
            ListOfDrivingLiscence.Add(
               new SelectListItem { Text = "Select Job", Value = null }
               );
            foreach (var type in types)
            {
                ListOfDrivingLiscence.Add(
                new SelectListItem { Text = type.NameAr, Value = type.Id.ToString() }
                );
            }
            _DrivingLiscenceAr = ListOfDrivingLiscence;
        }
    }
}
