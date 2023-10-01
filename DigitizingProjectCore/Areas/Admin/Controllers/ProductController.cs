using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.Dto.ProductDto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key, int? categoryId, int? brandId, bool? isActive)
        {
            var _Products = await _productService.GetAll(key, categoryId, brandId, isActive);
            return View(_Products);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var _CreateUpdateProduct = await _productService.CreateInjectCategoriesAndBrands();
            return View(_CreateUpdateProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _productService.GetAll()) });
            }
            var _CreateUpdateProduct = await _productService.CreateInjectCategoriesAndBrands();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", _CreateUpdateProduct) });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _Product = await _productService.GetById(id);
            var _AddProductWithCategoryAndBrand = await _productService.UpdateInjectCategoriesAndBrands();
            _AddProductWithCategoryAndBrand = _mapper.Map(_Product, _AddProductWithCategoryAndBrand);
            return View(_AddProductWithCategoryAndBrand);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductDto dto)
        {
            await _productService.Update(dto);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _productService.GetAll()) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _Product = await _productService.GetById(id);
            var dto = _mapper.Map<CreateProductDto>(_Product);
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateProductDto dto)
        {
            await _productService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _productService.GetAll()) });
        }
    }
}
