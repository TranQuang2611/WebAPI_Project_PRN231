using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI_Project_PRN231.Api;
using WebAPI_Project_PRN231.DTO;

namespace WebAPI_Project_PRN231.Controllers
{
    public class ManagementController : Controller
    {

        private readonly CallApi _callApi;
        private readonly ISession _session;
        private UserDTO user = null;

        public ManagementController(CallApi callApi, IHttpContextAccessor httpContextAccessor)
        {
            _callApi = callApi;
            _session = httpContextAccessor.HttpContext.Session;
            string stringUser = _session.GetString("user");
            if (!string.IsNullOrEmpty(stringUser))
            {
                user = JsonConvert.DeserializeObject<UserDTO>(stringUser);
            }
        }

        public IActionResult Index()
        {
            if(user == null || !user.IsAdmin)
            {
                return Redirect("/Home/Error");
            }

            return View();
        }
    }
}
