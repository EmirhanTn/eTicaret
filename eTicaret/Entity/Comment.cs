using eTicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaret.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public virtual Product Product { get; set; }



        public virtual List<CommentLine> Commentlines { get; set; }


    }

    public class CommentLine
    {

        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }

        public string CommentsDes { get; set; }

    

    }
}