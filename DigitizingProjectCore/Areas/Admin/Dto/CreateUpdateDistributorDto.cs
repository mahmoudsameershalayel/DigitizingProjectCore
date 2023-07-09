using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateDistributorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name (English) is required.")]
        public string NameEn { get; set; } = string.Empty;
        [Required(ErrorMessage = "Name (Arabic) is required.")]
        public string NameAr { get; set; } = string.Empty;
        [Required(ErrorMessage = "City is required.")]
        public int CityId { get; set; }
        public int? SortId { get; set; }
        [Required(ErrorMessage = "Address (English) is required.")]
        public string AddressEn { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address (Arabic) is required.")]
        public string AddressAr { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
    public class AddDistibutorWithCity : CreateUpdateDistributorDto
    {
        public IEnumerable<SelectListItem> _Cities { get; set; }

        public void InjectCities(List<City> cities)
        {
            List<SelectListItem> ListOfCities = new List<SelectListItem>();
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
