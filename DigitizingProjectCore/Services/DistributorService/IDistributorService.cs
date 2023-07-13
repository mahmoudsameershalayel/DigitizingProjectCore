using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.DistributorService
{
    public interface IDistributorService
    {
        public Task<List<DistributorViewModel>> GetAll();
        public Task<Distributor> GetById(int id);
        public Task<CreateUpdateDistributorDto> Create(CreateUpdateDistributorDto dto);
        public Task<CreateUpdateDistributorDto> Update(CreateUpdateDistributorDto dto);
        public Task<int> Delete(int id);
        public Task<CreateUpdateDistributorDto> InjectCities();
    }
}
