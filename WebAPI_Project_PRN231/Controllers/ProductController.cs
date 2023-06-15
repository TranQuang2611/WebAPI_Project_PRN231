using Microsoft.AspNetCore.Mvc;
using WebAPI_Project_PRN231.DTO;

namespace WebAPI_Project_PRN231.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index(SearchForm modelSearch)
        {
            return View("Index");
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
