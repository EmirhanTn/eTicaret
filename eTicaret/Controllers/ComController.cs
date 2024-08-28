using eTicaret.Entity;
using eTicaret.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTicaret.Controllers
{
    public class ComController : Controller
    {
        // GET: Com
        private DataContext db = new DataContext();
        public ActionResult Index(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == id);
            var comments = db.CommentLines
                .Where(i => i.ProductId == id)
                .Select(i => new CommentLineModel()
                {
                    UserName= i.UserName,
                    CommentsDes = i.CommentsDes,
                    ProductId = i.ProductId,
                    
                }).ToList();

            var productCommentModel = new ProductCommentModel
            {
                Product = product,
                Commentlines = comments
            };

            return View(productCommentModel);
        }
           
   

        public ActionResult AddComment(string CommentDes)
        {
            int id = Convert.ToInt32(Session["ProductId"]);
            string text = CommentDes;
            var product = db.Products.FirstOrDefault(i => i.Id == id);


            db.CommentLines.Add(new CommentLine() { Id = Guid.NewGuid(), ProductId = product.Id, UserName = User.Identity.Name, CommentsDes = CommentDes  });
            db.SaveChanges();
            return RedirectToAction("Index", new { id = product?.Id });
        }

        public ActionResult RemoveComment(int Id)
        {


            int id = Convert.ToInt32(Session["ProductId"]);
            var product = db.Products.FirstOrDefault(i => i.Id == id);
            var comment = db.CommentLines.FirstOrDefault(i => i.ProductId == Id && i.UserName == User.Identity.Name  );

          
            if (comment != null)
            {
                db.CommentLines.Remove(comment);
                db.SaveChanges();
            }

            return RedirectToAction("Index", new { id = comment?.ProductId });
        }

       
    }
}