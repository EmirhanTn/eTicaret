using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTicaret.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage ="Yanlış Eposta Kullanımı")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Şifre tekrar")]
        [Compare("Password", ErrorMessage ="Şifreler farklı.")]
        public string RePassword { get; set; }
    }
}