using DigitizingProjectCore.Dto;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

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
            var _UserUsername = await _userManager.FindByNameAsync(dto.Username);
            if (_UserUsername == null)
            {
                var _UserEmail = await _userManager.FindByEmailAsync(dto.Username);
                if (_UserEmail == null)
                {
                    throw new Exception("Not Found!!");
                }
                var result1 = await _signInManager.PasswordSignInAsync(_UserEmail, dto.Password, false, false);
                if (result1.Succeeded)
                {
                    return true;
                }
            }
            else {
                var result = await _signInManager.PasswordSignInAsync(_UserUsername, dto.Password, false, false);
                if (result.Succeeded)
                {
                    return true;
                }
            }  
            return false;
        }
        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
