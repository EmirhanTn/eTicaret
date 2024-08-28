using eTicaret.Entity;
using eTicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;

namespace eTicaret.Controllers
{
    [Authorize(Roles = "admin")]

    public class OrderController : Controller
    {

        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.Orderlines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                Username = i.Username,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                AdresBasligi = i.AdresBasligi,
                Adres = i.Adres,
                Il = i.Il,
                Ilce = i.Ilce,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                {

                    ProductId = a.ProductId,
                    ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 60) + "..." : a.Product.Name,
                    Quantity = a.Quantity,
                    Price = a.Price

                }).ToList()

            }).FirstOrDefault();

            return View(entity);


        }


        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);

            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgileriniz kaydedildi.";
                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
    }
}