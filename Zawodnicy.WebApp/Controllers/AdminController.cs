using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zawodnicy.WebApp.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        //GET: AdminController
        public IActionResult Index()
        {
            return View();
        }
    }
}
