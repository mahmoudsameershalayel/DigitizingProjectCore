using DigitizingProjectCore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Services.Auth
{
    public interface IAuthService
    {
        public Task<bool> Login(LoginDto dto);
        public Task<bool> Logout();

    }
}
