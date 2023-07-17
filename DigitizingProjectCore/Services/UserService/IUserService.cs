using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.UserService
{
    public interface IUserService
    {
        public Task<List<UserViewModel>> GetAll();
        public Task<CreateUserDto> GetById(string id);
        public Task<UpdateUserDto> GetByIdForEdit(string id);
        public Task<ResetPasswordDto> GetByIdForReset(string id);
        public Task<List<Link>> GetLinks();
        public Task<CreateUserDto> Create(CreateUserDto dto);
        public Task<UpdateUserDto> Update(UpdateUserDto dto);
        public Task<int> RestPassword(ResetPasswordDto dto);
        public Task<int> Delete(string id);
    }
}
