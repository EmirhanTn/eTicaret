using eTicaret.Entity;
using eTicaret.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTicaret.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products
               .Where(i => i.IsHome && i.IsApproved)
               .Select(i => new ProductModel()
               {
                   Id = i.Id,
                   Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                   Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                   Price = i.Price,
                   Stock = i.Stock,
                   Image = i.Image,
                   CategoryId = i.CategoryId,
                   
                  
               }).ToList();

            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            Session["ProductId"] = id;
            var product = _context.Products.Where(i => i.Id == id).FirstOrDefault();

            if (product == null)
            {
                return HttpNotFound();
            }

            var userName = User.Identity.Name;
            var isFav = _context.favoriteTables.Any(i => i.ProductId == id && i.UserName == userName);

            var model = new ProductDetailsViewModel
            {
                Product = product,
                IsFav = isFav
            };

            return View(model);
        }
        public ActionResult List(int? id)
        {
            var urunler = _context.Products
               .Where(i => i.IsApproved)
               .Select(i => new ProductModel()
               {
                   Id = i.Id,
                   Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                   Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                   Price = i.Price,
                   Stock = i.Stock,
                   Image = i.Image ?? "i.jpg",
                   CategoryId = i.CategoryId
                    
               }).AsQueryable();

            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);

            }

            return View(urunler);
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }

        public ActionResult Comment(int id)
        {

            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault());
            
        }


    }
}