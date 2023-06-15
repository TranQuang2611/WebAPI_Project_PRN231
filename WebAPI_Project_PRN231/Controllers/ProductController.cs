using Microsoft.AspNetCore.Mvc;
using WebAPI_Project_PRN231.Api;
using WebAPI_Project_PRN231.DTO;

namespace WebAPI_Project_PRN231.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(SearchForm modelSearch)
        {
            List<ColorDTO> colors = await new CallApi().GetAllColors();
            return View("Index");
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
