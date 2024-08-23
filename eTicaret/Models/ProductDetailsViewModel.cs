using eTicaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaret.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public bool IsFav { get; set; }

        //public virtual CommentLineModel CommentLineModel { get; set; }
    }
}