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
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        public UserController(IUserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Users = await _userService.GetAll();
            ViewBag.db = _context;
            return View(_Users);
        }
        [HttpGet]
        public  IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateUserDto dto)
        {
            dto.Id = "0";
            if (ModelState.IsValid)
            {
                await _userService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var _User = await _userService.GetById(id);
            return View(_User);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                await _userService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var _User = await _userService.GetById(id);
            return View(_User);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateUserDto dto)
        {
            await _userService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _userService.GetAll()) });
        }
    }
}
