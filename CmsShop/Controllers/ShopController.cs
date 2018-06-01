using CmsShop.Models.Data;
using CmsShop.Models.ViewModels.Shop;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CmsShop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pages");
        }


        public ActionResult CategoryMenuPartial()
        {
            // deklarujemy CategoryVM list
            List<CategoryVM> categoryVMList;

            // inicjalizacja listy
            using (Db db = new Db())
            {
                categoryVMList = db.Categories
                                   .ToArray()
                                   .OrderBy(x => x.Sorting)
                                   .Select(x => new CategoryVM(x))
                                   .ToList();
            }

            // zwracamy partial z lista
            return PartialView(categoryVMList);
        }

        // GET: /shop/category/name
        public ActionResult Category(string name)
        {
            // deklaracja productVMList
            List<ProductVM> productVMList;

            using (Db db = new Db())
            {
                // pobranie id kategorii
                CategoryDTO categoryDTO = db.Categories.Where(x => x.Slug == name).FirstOrDefault();
                int catId = categoryDTO.Id;

                // inicjalizacja listy produktów
                productVMList = db.Products
                                  .ToArray()
                                  .Where(x => x.CategoryId == catId)
                                  .Select(x => new ProductVM(x)).ToList();

                // pobieramy nazwe kategori
                var productCat = db.Products.Where(x => x.CategoryId == catId).FirstOrDefault();
                ViewBag.CategoryName = productCat.CategoryName;
            }

            // zwracamy widok z lista produktów z danej kategorii
            return View(productVMList);
        }

        // GET: /shop/product-szczegoly/name
        [ActionName("product-szczegoly")]
        public ActionResult ProductDetails(string name)
        {
            // deklaracja productVM i productDTO
            ProductVM model;
            ProductDTO dto;

            // Inicjalizacja product id
            int id = 0;

            using (Db db = new Db())
            {
                // sprawdzamy czy produkt istnieje
                if (!db.Products.Any(x => x.Slug.Equals(name)))
                {
                    return RedirectToAction("Index", "Shop");
                }

                // inicjalizacja productDTO
                dto = db.Products.Where(x => x.Slug == name).FirstOrDefault();

                // pobranie id
                id = dto.Id;

                // inicjalizacja modelu
                model = new ProductVM(dto);
            }

            // pobieramy galerie zdjec dla wybranegoproduktu
            model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs"))
                                           .Select(fn => Path.GetFileName(fn));

            // zwracamy wido z modelem
            return View("ProductDetails", model);
        }
    }
}