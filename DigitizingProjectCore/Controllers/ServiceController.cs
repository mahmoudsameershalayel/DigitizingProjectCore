﻿using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int? id)
        {
            var service = _context.CategoryForServices.Where(x => x.IsDelete == false && x.IsActive == true && (x.Id == id)).OrderBy(x => x.SortId).FirstOrDefault();
            var item = _context.Services.Where(x => x.IsDelete == false && x.IsActive == true && x.CategoryId == id).FirstOrDefault();
            if (item == null)
            {
                throw new Exception("Not Found!!");
            }
            return View(service);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = _context.Services.Where(x => x.IsDelete == false && x.IsActive == true && x.Id == id).Include(x => x.Category).FirstOrDefault();
            if (item == null)
            {
                throw new Exception("Not Found!!");
            }
            return View(item);
        }
    }
}
