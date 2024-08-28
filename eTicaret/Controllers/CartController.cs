using eTicaret.Entity;
using eTicaret.Models;

//using eTicaretsonson21.Entity;
//using eTicaretsonson21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace eTicaretsonson21.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var carts = db.Carts
                .Where(i => i.UserName == username)
                .Select(i => new UserCartModel()
                {
                    UserName = i.UserName,
                    Price = i.Product.Price,
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name.Length > 50 ? i.Product.Name.Substring(0, 47) + "..." : i.Product.Name,
                    Image = i.Product.Image,
                    Quantitycart = i.Quantitycart,
                    Product = i.Product

                }).ToList();

            double totalPrice = carts.Sum(item => item.Price * item.Quantitycart);


            ViewBag.TotalPrice = totalPrice;


            return View(carts);
        }

        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product == null)
            {


                return RedirectToAction("Index");
            }

            var username = User.Identity.Name;


            var existingCart = db.Carts.FirstOrDefault(i => i.ProductId == Id && i.UserName == username);

            if (existingCart == null)
            {

                db.Carts.Add(new CartTable()
                {
                    ProductId = product.Id,
                    UserName = username,
                    Quantitycart = 1
                });
            }
            else
            {

                existingCart.Quantitycart += 1;
            }


            db.SaveChanges(); 

            return RedirectToAction("Index");
        }
        public ActionResult RemoveToCart(int Id)
        {
            var cartItem = db.Carts.FirstOrDefault(i => i.ProductId == Id && i.UserName == User.Identity.Name);

            if (cartItem != null)
            {
                if (cartItem.Quantitycart > 1)
                {

                    cartItem.Quantitycart -= 1;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public ActionResult RemoveFromCart(int Id)
        {
            var cartItem = db.Carts.FirstOrDefault(i => i.ProductId == Id && i.UserName == User.Identity.Name);

            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            var userName = User.Identity.Name;
            var addresses = db.adresses.Where(a => a.UserName == userName).ToList();
            return View(addresses); 
        }


        [HttpPost]
        public ActionResult SaveOrder(int selectedAddressId)
        {
           
            var selectedAddress = db.adresses.SingleOrDefault(a => a.Id == selectedAddressId);
            

            var order = new Order
            {
                OrderNumber = "A" + new Random().Next(11111, 99999),
                OrderDate = DateTime.Now,
                OrderState = EnumOrderState.Waiting,
                Username = User.Identity.Name,
                AdresBasligi = selectedAddress.AdresBasligi,
                Adres = selectedAddress.Adres,
                Il = selectedAddress.Il,
                Ilce = selectedAddress.Ilce,
                Mahalle = selectedAddress.Mahalle,
                PostaKodu = selectedAddress.PostaKodu,
                Orderlines = new List<OrderLine>()
            }; 

            var cartItems = db.Carts.Where(i => i.UserName == User.Identity.Name).ToList();
            double totalOrderPrice = 0;

            foreach (var cartItem in cartItems)
            {
                var orderline = new OrderLine
                {
                    Quantity = cartItem.Quantitycart,
                    Price = cartItem.Quantitycart * cartItem.Product.Price,
                    ProductId = cartItem.Product.Id
                };

                order.Orderlines.Add(orderline);
                totalOrderPrice += orderline.Price;
            }

            order.Total = totalOrderPrice;
            db.Orders.Add(order);
            db.SaveChanges();

            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();

            return RedirectToAction("Index"); 
        }

       
  
    }
}

