using eTicaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaret.Models
{
    public class UserCartModel
    {
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }

        public string ProductName { get; set; }

        public int Id { get; set; }
        public string Image { get; set; }


        public int Quantitycart { get; set; }

        public double Price { get; set; }

        public virtual Product Product { get; set; }
    }
}