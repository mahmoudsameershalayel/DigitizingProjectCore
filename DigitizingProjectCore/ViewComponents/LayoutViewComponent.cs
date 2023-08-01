using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.ViewComponents
{
    public class LayoutViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public LayoutViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.db = _context;
            return Task.FromResult<IViewComponentResult>(View());
        }
    }   
}
