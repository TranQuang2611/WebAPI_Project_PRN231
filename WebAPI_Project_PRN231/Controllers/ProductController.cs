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
            List<RamDTO> rams = await new CallApi().GetAllRams();
            List<CategoryDTO> categories = await new CallApi().GetAllCategory();
            List<SizeDTO> sizes = await new CallApi().GetAllSizes();
            List<BrandDTO> brands = await new CallApi().GetAllBrand();
            if(modelSearch.nameProd == null) {
                modelSearch.nameProd = ""; 
            }
            List<ProductDTO> products = await new CallApi().SearchProduct(modelSearch);
            ViewBag.listColor = colors;
            ViewBag.listRam = rams;
            ViewBag.Size = sizes;
            ViewBag.listCategory = categories;
            ViewBag.listBrand = brands;
            ViewBag.modelSearch = modelSearch;
            return View("Index", products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            ProductDTO product = await new CallApi().GetProductDetail(id);
            if(product == null)
            {
                return Redirect("/Home/Error");
            }
            return View(product);
        }

        public async Task<IActionResult> ReviewComponent(ReviewModel model)
        {
            List<ReviewDTO> reviews = await new CallApi().GetReviewOfProduct(model);
            return PartialView(reviews);
        }

    }
}
