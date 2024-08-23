using eTicaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaret.Models
{
    public class ProductCommentModel
    {
        public virtual Product Product { get; set; }



        public virtual List<CommentLineModel> Commentlines { get; set; }

    }
        public class CommentLineModel
        {
            public virtual Product Product { get; set; }

            public int Id { get; set; }
            public string UserName { get; set; }

            public int ProductId { get; set; }

            public string CommentsDes { get; set; }




        }
    }
