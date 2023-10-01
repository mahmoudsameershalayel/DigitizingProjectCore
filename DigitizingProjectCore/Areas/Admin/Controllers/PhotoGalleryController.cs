using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CategoryServiceService;
using DigitizingProjectCore.Services.PhotoGalleryService;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class PhotoGalleryController : AdminBaseController
    {
        private readonly IPhotoGalleryService _photoGalleryService;

        public PhotoGalleryController(IPhotoGalleryService photoGalleryService)
        {
            _photoGalleryService = photoGalleryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key , bool? isActive )
        {
            var _Categories = await _photoGalleryService.GetAll(key , isActive);
            return View(_Categories);
        }
        [HttpPost]
        public async Task<ActionResult> Search(string term = "")
        {
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _photoGalleryService.Search(term)) });
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdatePhotoGalleryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _photoGalleryService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _photoGalleryService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _category = await _photoGalleryService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdatePhotoGalleryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _photoGalleryService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _photoGalleryService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _PhotoGallery = await _photoGalleryService.GetById(id);
            return View(_PhotoGallery);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdatePhotoGalleryDto dto)
        {
            await _photoGalleryService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _photoGalleryService.GetAll()) });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteImage(int id, string imageNames) {
            var _PhotoGallery = await _photoGalleryService.GetById(id);
            int result = await _photoGalleryService.DeleteImage(id, imageNames);
            if (result != 0) {
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", _PhotoGallery) });
            }
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _photoGalleryService.GetAll()) });
        }
    }
}
