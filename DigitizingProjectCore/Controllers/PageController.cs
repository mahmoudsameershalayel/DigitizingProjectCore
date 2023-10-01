using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index([FromServices] ApplicationDbContext _context ,  string id)
        {
            var page = _context.Pages.Where(x => x.IsActive == true && x.IsDelete == false && x.Slug.Equals(id)).FirstOrDefault();
            return View(page);
        }
    }
}
