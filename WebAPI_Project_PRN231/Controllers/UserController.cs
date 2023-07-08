using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI_Project_PRN231.Api;
using WebAPI_Project_PRN231.DTO;

namespace WebAPI_Project_PRN231.Controllers
{
    public class UserController : Controller
    {
        private readonly CallApi _callApi;
        private readonly ISession _session;
        public UserController(CallApi callApi, IHttpContextAccessor httpContextAccessor)
        {
            _callApi = callApi;
            _session = httpContextAccessor.HttpContext.Session;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            string sessionUser = _session.GetString("user");
            if(string.IsNullOrEmpty(sessionUser))
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
            else
            {
                return Redirect("/Home/Index");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Logon(LoginModel model)
        {
            ApiRespond respond = await _callApi.Login(model);
            if(respond != null)
            {
                _session.SetString("token", respond.Token);
                string user = JsonConvert.SerializeObject(respond.UserDTO);
                _session.SetString("user", user);
            }
            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            return Redirect("/Home/Index");
        }

        public IActionResult Logout()
        {
            _session.Clear();
            return Redirect("/Home/Index");
        }
    }
}
