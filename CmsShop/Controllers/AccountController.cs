using CmsShop.Models.Data;
using CmsShop.Models.ViewModels.Account;
using System.Linq;
using System.Web.Mvc;

namespace CmsShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return Redirect("~/account/login");
        }

        // GET: /account/login
        public ActionResult Login()
        {
            // sprawdzanie czy uzytkownik nie jest juz zalogowany
            string userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
                return RedirectToAction("user-profile");

            // zwracamy widok
            return View();
        }

        // GET: /account/create-account
        [ActionName("create-account")]
        [HttpGet]
        public ActionResult CreateAccount()
        {

            return View("CreateAccount");
        }

        // POST: /account/create-account
        [ActionName("create-account")]
        [HttpPost]
        public ActionResult CreateAccount(UserVM model)
        {
            // sprawdzenie model state
            if (!ModelState.IsValid)
            {
                return View("CreateAccount", model);
            }

            // sprawdzenie hasła
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                ModelState.AddModelError("", "Hasła nie pasują do siebie");
                return View("CreateAccount", model);
            }

            using (Db db = new Db())
            {
                // sprawdzenie czy nazwa uzytkownika jest unikalna
                if (db.Users.Any(x => x.UserName.Equals(model.UserName)))
                {
                    ModelState.AddModelError("", "Nazwa użytkownika " + model.UserName + " jest już zajęta");
                    model.UserName = "";
                    return View("CreateAccount", model);
                }

                // utworzenie uzytkownika
                UserDTO usserDTO = new UserDTO()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    UserName = model.UserName,
                    Password = model.Password,
                };

                // dodanie uzytkownika
                db.Users.Add(usserDTO);
                // zapis na bazie
                db.SaveChanges();

                // dodanie roli dla uzytkownika
                UserRoleDTO userRoleDTO = new UserRoleDTO()
                {
                    UserId = usserDTO.Id,
                    RoleId = 2
                };

                // dodanie roli
                db.UserRoles.Add(userRoleDTO);
                // zapis na bazie
                db.SaveChanges();
            }

            // TempData komunikat
            TempData["SM"] = "Jesteś teraz zarejestrowany i możesz się zalogować!";


            return Redirect("~/account/login");
        }
    }
}