using Microsoft.AspNetCore.Http;
using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monafasati.Web.ViewModel
{
    public class MonafastViewModel
    {

        [Display(Name = "اسم المناقصة")]
        public string Name { get; set; }

        [Display(Name = "الجهه المعلنة")]
        public string Advertiser { get; set; }

        [Display(Name = "اخر موعد للتسليم")]
        public DateTime LastDate { get; set; }

        [Display(Name = " قيمة الكراسة")]
        public int Price { get; set; }
        public Statu Statu { get; set; }
        [Display(Name = " وضع المنافسة")]
        public int StatuId { get; set; }

        public Engineer Engineer { get; set; }

        [Display(Name = "الشخص المسؤول")]
        public int EngineerId { get; set; }
        [Display(Name = "رقم سداد")]
        public double Sadad { get; set; }
        [Display(Name = "ملاحظات")]
        public string Note { get; set; }

        [Display(Name = " ملف المناقصة")]
        public IFormFile PdfFile { get; set; }
    }
}
