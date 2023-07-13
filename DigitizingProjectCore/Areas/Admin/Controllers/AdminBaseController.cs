using Azure;
using Castle.MicroKernel.Registration;
using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    [Route("[area]/[controller]/[action]")]

    public class AdminBaseController : Controller
    {
       
    }
}
