using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace eTicaret.Models
{
    public class AdressModel
    {
        [Required(ErrorMessage = "Lütfen Ad Girin")]
        [DisplayName("Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyad Girin")]
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Adı Girin")]
        [DisplayName("Adres Adı")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Girin")]
        [DisplayName("Adres")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen il Girin")]
        [DisplayName("İl")]
        public string Il { get; set; }
        [Required(ErrorMessage = "Lütfen İlçe Girin")]
        [DisplayName("İlçe")]
        public string Ilce { get; set; }
        [Required(ErrorMessage = "Lütfen Mahalle Girin")]
        [DisplayName("Mahalle")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "Lütfen Posta Kodu Girin")]
        [DisplayName("Posta Kodu")]
        public string PostaKodu { get; set; }

    }
}