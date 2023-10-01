using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore
{
    public class UrlAccessMiddleware
    {
        private readonly RequestDelegate _next;
        public UrlAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, [FromServices] ApplicationDbContext _context, [FromServices] UserManager<ApplicationUser> _userManager)
        {
            // Your authentication and URL access logic here

            // Example: Check if the user is allowed to access the requested URL
            if (!(await IsUserAllowed(context.User.Identity.Name, context.Request.Path, _context, _userManager)))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next(context);
        }

        private async Task<bool> IsUserAllowed(string userName, PathString requestedPath, ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            if (userName == null)
            {
                return true;
            }
            var user = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.UserName == userName).FirstOrDefaultAsync(); 
            if (user != null)
            {
                var links = await _context.AdminLinks.Where(x => x.AdminId.Equals(user.Id)).Include(x => x.Link).ToListAsync();
                foreach (var link in links)
                {
                    if (link.Link.URL.Equals(requestedPath) || requestedPath.Equals("/Admin/Home/Index"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
