﻿using DigitizingProjectCore.Dto;
using DigitizingProjectCore.Services.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
        public IActionResult Login(string? ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var IsSuccess = await _authService.Login(dto);
            if (IsSuccess)
            {
                if (dto.ReturnUrl != null)
                {
                    return LocalRedirect(dto.ReturnUrl);
                }
                else
                {
                    return LocalRedirect("/Admin/Home/Index");
                }
            }
            TempData["msg"] = "e: خطأ قي اسم المستخدم أو كلمة المرور";
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
