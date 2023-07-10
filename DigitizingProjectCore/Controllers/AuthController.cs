using DigitizingProjectCore.Dto;
using DigitizingProjectCore.Services.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login(string? ReturnUrl) {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try {
                var IsSuccess = await _authService.Login(dto);
                if (IsSuccess)
                {
                    return LocalRedirect(dto.ReturnUrl);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
