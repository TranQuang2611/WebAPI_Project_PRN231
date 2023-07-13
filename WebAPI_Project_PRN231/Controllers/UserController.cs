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
                ViewBag.mess = "";
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
                if(respond.Success)
                {
                    _session.SetString("token", respond.Token);
                    string user = JsonConvert.SerializeObject(respond.UserDTO);
                    _session.SetString("user", user);
                }
                else
                {
                    ViewBag.mess = respond.Message;
                    return View("Login");
                }
                
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

        public async Task<IActionResult> Register(RegisterModel model)
        {
            string mess = "";
            bool isSuccess = true;
            try
            {
                if (model.UserName != "" && model.Password != "")
                {
                    mess =  await _callApi.Register(model);
                    if(mess != "") {
                        isSuccess = false;
                    }
                    else
                    {
                        mess = "Đăng kí thành công tài khoản (" + model.UserName.Trim() + ")";
                    }
                }
            }
            catch (Exception)
            {
                isSuccess = false;
                mess = "Có lỗi xảy ra";
            }
            ViewBag.mess = mess;
            ViewBag.isSuccess = isSuccess;
            return View();
        }
    }
}
