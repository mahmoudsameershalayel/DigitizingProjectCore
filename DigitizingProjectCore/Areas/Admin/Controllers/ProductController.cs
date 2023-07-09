using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper  mapper, ApplicationDbContext context)
        {
            _productService = productService;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Products = await _productService.GetAll();
            ViewBag.db = _context;
            return View(_Products);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var _CreateUpdateProduct = await _productService.InjectCategoriesAndBrands();
            return View(_CreateUpdateProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _Product = await _productService.GetById(id);
            var _AddProductWithCategoryAndBrand = await _productService.InjectCategoriesAndBrands();
            _AddProductWithCategoryAndBrand = _mapper.Map(_Product, _AddProductWithCategoryAndBrand);
            return View(_AddProductWithCategoryAndBrand);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Json(new { id = id, message = "Deleted Successfully" });
        }
    }
}
