using CmsShop.Models.Data;
using CmsShop.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsShop.Controllers
{
    public class PagesController : Controller
    {
        // GET: Index/{pages}
        public ActionResult Index(string page = "")
        {
            // ustawiamy adres naszej strony
            if (page == "")
                page = "home";

            // deklarujemy pageVM i pageDTO
            PageVM model;
            PageDTO dto;

            // sprawdzamy czy strona istnieje
            using (Db db = new Db())
            {
                if (!db.Pages.Any(x => x.Slug.Equals(page)))
                    return RedirectToAction("Index", new { page = "" });
            }

            // pobieramy pageDTO
            using (Db db = new Db())
            {
                dto = db.Pages.Where(x => x.Slug == page).FirstOrDefault();
            }

            // ustawiamy tytul naszej strony
            ViewBag.PageTitle = dto.Title;

            // sprawdzamy czy strona ma pasek boczny
            if (dto.HasSidebar == true)
                ViewBag.Sidebar = "Tak";
            else
                ViewBag.Sidebar = "Nie";

            // inicjalizujemy pageVM
            model = new PageVM(dto);

            // zwracamy widok z pageVM
            return View(model);
        }
    }
}