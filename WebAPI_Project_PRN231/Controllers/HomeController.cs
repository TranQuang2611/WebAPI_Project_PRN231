using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using WebAPI_Project_PRN231.Api;
using WebAPI_Project_PRN231.DTO;
using WebAPI_Project_PRN231.Models;

namespace WebAPI_Project_PRN231.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;

        public HomeController(ILogger<HomeController> logger, CallApi callApi, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _callApi = callApi;
        }

        public async Task<IActionResult> Index()
        {
            var listProd = await _callApi.GetNewestProduct<ProductDTO>();
            var listFeatureProd = await _callApi.GetFeatureProd<ProductDTO>();
            ViewBag.listFeatureProd = listFeatureProd;
            return View("Index", listProd);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}