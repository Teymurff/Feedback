using System.Web.Mvc;

namespace Vizew.WebUI.Controllers
{
    //[RoutePrefix("Account")]
    public class AccountController : Controller
    {
        // GET: Account/login
        [Route("Account/Login")]
        public ActionResult Index()
        {
            return View();
        }

        //Account/List
        public ActionResult List()
        {
            return View();
        }
    }
}