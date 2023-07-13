using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.UserService
{
    public interface IUserService
    {
        public Task<List<UserViewModel>> GetAll();
        public Task<CreateUpdateUserDto> GetById(string id);
        public Task<CreateUpdateUserDto> Create(CreateUpdateUserDto dto);
        public Task<CreateUpdateUserDto> Update(CreateUpdateUserDto dto);
        public Task<int> Delete(string id);
    }
}
