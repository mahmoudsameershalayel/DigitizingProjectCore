using DigitizingProjectCore.Dto;

namespace DigitizingProjectCore.Services.Auth
{
    public interface IAuthService
    {
        public Task<bool> Login(LoginDto dto);
    }
}
