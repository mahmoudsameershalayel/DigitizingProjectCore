using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.ServiceService
{
    public interface IServiceService
    {
        public Task<List<ServiceViewModel>> GetAll();
        public Task<List<ServiceViewModel>> GetAll(string? key , int? categoryId , bool? isActive);
        public Task<CreateUpdateServiceDto> GetDtoById(int id);
        public Task<Service> GetServiceById(int id);
        public Task<CreateUpdateServiceDto> Create(CreateUpdateServiceDto dto);
        public Task<CreateUpdateServiceDto> Update(CreateUpdateServiceDto dto);
        public Task<CreateUpdateServiceDto> InjectCategories();
        public Task<int> Delete(int id);
    }
}
