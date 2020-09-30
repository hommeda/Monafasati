using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Monafasati.Core.Entity
{
   public class Monafsa
    {
        public int Id { get; set; }
        
       [Display(Name ="اسم المناقصة")]
        public string Name { get; set; }

        [Display(Name ="الجهه المعلنة")]
        public string Advertiser { get; set; }

        [Display(Name = "اخر موعد للتسليم")]
        public DateTime LastDate { get; set; }

        [Display(Name = " قيمة الكراسة")]
        public int Price { get; set; }
        [Display(Name = " وضع المنافسة")]
        public Statu Statu { get; set; }
        [Display(Name = " وضع المنافسة")]
        public int StatuId { get; set; }
       
        [Display(Name ="الشخص المسؤول")]
        public Engineer Engineer { get; set; }
       
        [Display(Name = "الشخص المسؤول")]
        public int EngineerId { get; set; }
        [Display(Name = "رقم سداد")]
        public double Sadad { get; set; }
        [Display(Name = "ملاحظات")]
        public string Note { get; set; }

        [Display(Name = " ملف المناقصة")]
        public string PdfFile { get; set; }
    }
}
