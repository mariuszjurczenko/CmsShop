using CmsShop.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CmsShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest()
        {
            if (User == null)
            {
                return;
            }

            // pobieramy nazwe uzytkownika
            string username = Context.User.Identity.Name;

            // deklarujemy tablice z rolami
            string[] roles = null;

            using (Db db = new Db())
            {
                // pobieramy dane dla uzytkownika z bazy aby pobrac role
                UserDTO dto = db.Users.FirstOrDefault(x => x.UserName == username);
                roles = db.UserRoles.Where(x => x.UserId == dto.Id).Select(x => x.Role.Name).ToArray();
            }

            // tworzymy IPrincipal object
            IIdentity userIdentity = new GenericIdentity(username);
            IPrincipal newUserObj = new GenericPrincipal(userIdentity, roles);

            // update Context.User
            Context.User = newUserObj;
        }
    }
}
