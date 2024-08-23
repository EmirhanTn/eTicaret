using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eTicaret.Entity;
using eTicaret.Models;

namespace eTicaret.Controllers
{
    public class AdressesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Adresses
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            var addresses = db.adresses.Where(a => a.UserName == userName).ToList();
            return View(addresses);
        }

        // GET: Adresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.adresses.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        // GET: Adresses/Create
        public ActionResult Create()
        {
      
            return View();
        }

        // POST: Adresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdressModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name; // Get current user name
                var adress = new Adress
              
                {
                    UserName = User.Identity.Name, // Assuming user is logged in, use their username
                    Name = model.Name,
                    Surname = model.Surname,
                    AdresBasligi = model.AdresBasligi,
                    Adres = model.Adres,
                    Il = model.Il,
                    Ilce = model.Ilce,
                    Mahalle = model.Mahalle,
                    PostaKodu = model.PostaKodu
                };

                db.adresses.Add(adress);
                db.SaveChanges();
                return RedirectToAction("Index"); // Redirect to Profile page after saving
            }

            return View(model); // Return the view with the model in case of an error
        }

        // GET: Adresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.adresses.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        // POST: Adresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Name,Surname,AdresBasligi,Adres,Il,Ilce,Mahalle,PostaKodu")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adress);
        }

        // GET: Adresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.adresses.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        // POST: Adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adress adress = db.adresses.Find(id);
            db.adresses.Remove(adress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
