using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateDistributorDto
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public int CityId { get; set; }
        public int SortId { get; set; }
        public string AddressEn { get; set; } = string.Empty;
        public string AddressAr { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
    public class AddDistibutorWithCity : CreateUpdateDistributorDto
    {
        public IEnumerable<SelectListItem> _Cities { get; set; }

        public void InjectCategories(List<CreateUpdateDistributorDto> cities)
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
