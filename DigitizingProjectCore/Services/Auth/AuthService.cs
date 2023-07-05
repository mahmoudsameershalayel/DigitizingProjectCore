using DigitizingProjectCore.Dto;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;

namespace DigitizingProjectCore.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Login(LoginDto dto)
        {
            var _user = await _userManager.FindByEmailAsync(dto.Email);
            if (_user == null)
            {
                throw new Exception("Not Found!!");
            }
            var result = await _signInManager.PasswordSignInAsync(_user, dto.Password, false, false);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
