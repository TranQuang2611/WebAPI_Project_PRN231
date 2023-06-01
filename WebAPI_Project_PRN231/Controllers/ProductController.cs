using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Project_PRN231.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
