using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eTicaret.Entity;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.AspNet.Identity;


namespace eTicaret.Models
{
    public class Favorites
    {
        private List<FavLine> _favLines = new List<FavLine>();

        public List<FavLine> FavLines
        {
            get { return _favLines; }
        }

        public void AddProduct(FavoriteTable product, int quantity)
        {
            var line = _favLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line == null)
            {
                _favLines.Add(new FavLine() { Product = product, Quantity = quantity  });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

      


        public void DeleteProduct(FavoriteTable fav)
        {
            _favLines.RemoveAll(i => i.Product.Id == fav.Id);
        }

      

       
    }

    public class FavLine
    {
        public FavoriteTable Product { get; set; }
        public int Quantity { get; set; }

        
    }
}