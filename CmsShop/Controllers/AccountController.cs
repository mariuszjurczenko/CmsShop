using System.Web.Mvc;

namespace CmsShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: /account/create-account
        [ActionName("create-account")]
        public ActionResult CreateAccount()
        {

            return View("CreateAccount");
        }
    }
}