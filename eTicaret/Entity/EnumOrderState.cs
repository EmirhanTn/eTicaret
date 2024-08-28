using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTicaret.Entity
{
    public enum EnumOrderState
    {
        [Display(Name = "Onay Bekleniyor")]
        Waiting,
        [Display(Name="Tamamlandı")]
        Completed,
        [Display(Name = "Kargoya Verildi")]
        Shipping

    }
}