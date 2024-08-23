using eTicaret.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace eTicaret.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]

        public string Name { get; set; }
        [DisplayName("Açıklama")]

        public string Description { get; set; }
        [DisplayName("Fiyat")]

        public double Price { get; set; }
        [DisplayName("Stok Durumu")]

        public int Stock { get; set; }
        [DisplayName("Resim")]

        public string Image { get; set; }
        [DisplayName("Anasayfada mı?")]

        public bool IsHome { get; set; }
        [DisplayName("Listelensin mi?")]

        public bool IsApproved { get; set; }
        [DisplayName("Katagori")]

        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public int FavId { get; set; }
        public Category Category { get; set; }

     


        //public FavoriteTable FavoriteTableModel { get; set; }

    }



}