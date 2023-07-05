using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
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
        public async Task<IActionResult> Index()
        {
            var _Products = await _productService.GetAll();
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
            var _CreateUpdateProduct = _mapper.Map<CreateUpdateProductDto>(_Product);
            return View(_CreateUpdateProduct);
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
