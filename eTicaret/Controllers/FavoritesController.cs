
using eTicaret.Entity;
using eTicaret.Identity;
using eTicaret.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTicaret.Controllers
{
    public class FavoritesController : Controller
    {
        private DataContext db = new DataContext();
        private Product ProductModel = new Product();
        [Authorize]


        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var favoriler = db.favoriteTables
                .Where(i => i.UserName == username)
                .Select(i => new UserFavModel()
                {
                    UserName = i.UserName,
                    Price =i.Product.Price,
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name.Length > 50 ? i.Product.Name.Substring(0, 47) + "..." : i.Product.Name,
                    Image = i.Product.Image,

                }).ToList();

            return View(favoriler);
            
        }

        public ActionResult AddToFav(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            var existingFav = db.favoriteTables.FirstOrDefault(i => i.ProductId == Id && i.UserName == User.Identity.Name);

            if (existingFav == null)
            {
                db.favoriteTables.Add(new FavoriteTable() { ProductId = product.Id, UserName = User.Identity.Name, IsFav = true });
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

       

        public ActionResult RemoveFromFav(int Id)
        {
            var favorite = db.favoriteTables.FirstOrDefault(i => i.ProductId == Id && i.UserName == User.Identity.Name);

            if (favorite != null)
            {
                db.favoriteTables.Remove(favorite);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public Favorites GetFav()
        {
            var fav = (Favorites)Session["Cart"];

            if (fav == null)
            {
                fav = new Favorites();
                Session["Cart"] = fav;
            }

            return fav;
        }

    }
}