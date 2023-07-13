using Microsoft.AspNetCore.Mvc;
using WebAPI_Project_PRN231.Api;
using WebAPI_Project_PRN231.DTO;

namespace WebAPI_Project_PRN231.Controllers
{
    public class ProductController : Controller
    {
        private readonly CallApi _callApi;

        public ProductController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index(SearchForm modelSearch)
        {
            List<ColorDTO> colors = await _callApi.GetAllColors();
            List<RamDTO> rams = await _callApi.GetAllRams();
            List<CategoryDTO> categories = await _callApi.GetAllCategory();
            List<SizeDTO> sizes = await _callApi.GetAllSizes();
            List<BrandDTO> brands = await _callApi.GetAllBrand();
            if(modelSearch.nameProd == null) {
                modelSearch.nameProd = ""; 
            }
            List<ProductDTO> products = await _callApi.SearchProduct(modelSearch);
            ViewBag.listColor = colors;
            ViewBag.listRam = rams;
            ViewBag.Size = sizes;
            ViewBag.listCategory = categories;
            ViewBag.listBrand = brands;
            ViewBag.modelSearch = modelSearch;
            ViewBag.nameProd = modelSearch.nameProd;
            return View("Index", products);
        }

        public async Task<IActionResult> Detail(int id)
        {   
            ProductDTO product = await _callApi.GetProductDetail(id);
            if(product == null)
            {
                return Redirect("/Home/Error");
            }
            return View(product);
        }

        public async Task<IActionResult> ReviewComponent(ReviewModel model)
        {
            List<ReviewDTO> reviews = await _callApi.GetReviewOfProduct(model);
            return PartialView(reviews);
        }

        public async Task<IActionResult> HeaderReviewComponent(int productId)
        {
            ProductDTO product = await _callApi.GetProductDetail(productId);
            return PartialView(product);
        }

    }
}
