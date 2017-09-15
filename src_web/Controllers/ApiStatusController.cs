using Microsoft.AspNetCore.Mvc;

namespace src_web.Controllers
{
    [Route("api/Status")]
    public class ApiStatusController : Controller
    {
        public JsonResult Index()
        {
            return null;
        }
    }
}