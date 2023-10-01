using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.UserService
{
    public interface IUserService
    {
        public Task<List<UserViewModel>> GetAll();
        public Task<List<UserViewModel>> GetAll(string? key);
        public Task<CreateUserDto> GetById(string id);
        public Task<ApplicationUser> GetUserById(string id);
        public Task<UpdateUserDto> GetByIdForEdit(string id);
        public Task<ResetPasswordDto> GetByIdForReset(string id);
        public Task<bool> IsExist(string username, string email);
        public Task<List<Link>> GetLinks(); 
        public Task<int> Create(CreateUserDto dto);
        public Task<UpdateUserDto> Update(UpdateUserDto dto);
        public Task<int> RestPassword(ResetPasswordDto dto);
        public Task<int> UserPremissions(string userId, int[] linkIds);
        public Task<int> Delete(string id);
    }
}
