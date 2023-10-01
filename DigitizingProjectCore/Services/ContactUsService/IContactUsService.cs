using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.ContactUsService
{
    public interface IContactUsService
    {
        public Task<List<ContactUsViewModel>> GetAll();
        public Task<List<ContactUsViewModel>> GetAll(string? key);
        public Task<CreateContactUsDto> GetById(int id);
        public Task<int> EditReaded(int id ,bool isReaded);
        public Task<CreateContactUsDto> Create(CreateContactUsDto vm);
        public Task<int> Delete(int id);
    }
}
