using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateDistributorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name (English) is required.")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "Name (Arabic) is required.")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public int CityId { get; set; }
        public int? SortId { get; set; }
        [Required(ErrorMessage = "Address (English) is required.")]
        public string AddressEn { get; set; } 
        [Required(ErrorMessage = "Address (Arabic) is required.")]
        public string AddressAr { get; set; } 
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
    public class AddDistibutorWithCity : CreateUpdateDistributorDto
    {
        public IEnumerable<SelectListItem> _Cities { get; set; }

        public void InjectCities(List<City> cities)
        {
            List<SelectListItem> ListOfCities = new List<SelectListItem>();
            ListOfCities.Add(
                new SelectListItem { Text = "Select City", Value = "0" }
                );
            foreach (var city in cities)
            {
                ListOfCities.Add(
                new SelectListItem { Text = city.NameEn, Value = city.Id.ToString() }
                );
            }
            _Cities = ListOfCities;
        }
    }
}
