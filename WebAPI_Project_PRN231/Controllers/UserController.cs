using Microsoft.AspNetCore.Mvc;
using WebAPI_Project_PRN231.Api;
using WebAPI_Project_PRN231.DTO;

namespace WebAPI_Project_PRN231.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logon(LoginModel model)
        {
            ApiRespond respond = await new CallApi().Login(model);
            if(respond != null)
            {

            }
            return View("Login");
        }
    }
}
