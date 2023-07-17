using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.DistributorService;
using DigitizingProjectCore.Services.UserService;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Index([FromServices] ApplicationDbContext _context)
        {
            var _Users = await _userService.GetAll();
            ViewBag.db = _context;
            return View(_Users);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserDto dto)
        {
            dto.Id = "0";
            await _userService.Create(dto);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });

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
            await _userService.RestPassword(dto);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
        }
        [HttpGet]
        public async Task<IActionResult> UserPremissions()
        {
            var _Links = await _userService.GetLinks();
            var dto = new CreateUpdatePremissionDto();
            dto.Links = _Links;
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> UserPremissions(CreateUpdatePremissionDto dto)
        {
            var _Links = await _userService.GetLinks();
            return View(_Links);
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
