using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.DistributorService;
using DigitizingProjectCore.Services.UserService;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key)
        {
            var _Users = await _userService.GetAll(key);
            return View(_Users);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromServices] ApplicationDbContext _context , CreateUserDto dto)
        {
            dto.Id = "0";
            var isExist = await _userService.IsExist(dto.FullName , dto.Email);
            if (!isExist)
            {
                var result = await _userService.Create(dto);
                if (result == 1)
                {
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
                }
            }
            TempData["msg"] = "e: اسم المستخدم موجود مسبقا";
            return Add();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var _User = await _userService.GetByIdForEdit(id);
            return View(_User);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                await _userService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> ResetPassword(string id)
        {
            var _User = await _userService.GetByIdForReset(id);
            return View(_User);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            var result = await _userService.RestPassword(dto);
            if (result != 0)
            {
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "ResetPassword", dto) });


        }
        [HttpGet]
        public async Task<IActionResult> UserPremissions([FromServices] ApplicationDbContext _context, string id)
        {
            var item = await _userService.GetUserById(id);
            ViewBag.db = _context;
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> UserPremissions(string userId, int[] linkIds)
        {
            var _User = await _userService.GetUserById(userId);
            int result = await _userService.UserPremissions(userId, linkIds);
            if (result != 0)
            {
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "UserPremissions", _User) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var _User = await _userService.GetById(id);
            return View(_User);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUserDto dto)
        {
            await _userService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
        }
    }
}
