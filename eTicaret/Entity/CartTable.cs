using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaret.Entity
{
    public class CartTable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantitycart { get; set; }


    }
}