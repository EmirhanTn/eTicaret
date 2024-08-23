
using eTicaret.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eTicaret.Entity
{
    public class DataContext: DbContext
    {
        public DataContext() : base("default")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<FavoriteTable> favoriteTables { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentLine> CommentLines { get; set; }

        public DbSet<CartTable> Carts { get; set; }
        public DbSet<Adress> adresses { get; set; }


    }
}