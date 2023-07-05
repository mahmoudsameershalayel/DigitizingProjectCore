using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    [Route("[controller]/[action]")]

    public class AdminBaseController : Controller
    {
    }
}
