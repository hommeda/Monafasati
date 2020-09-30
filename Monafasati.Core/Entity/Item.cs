using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Monafasati.Core.Entity
{
    public class Item
    {
        public int Id { get; set; }

        [Display(Name = "كود المنتج")]
        public int ItemCode { get; set; }
        [Display(Name = "وصف الصنف")]
        public string Name { get; set; }


        [Display(Name = "العدد")]
        public int Count { get; set; }

        [Display(Name = "سعر الشراء")]
        public double Price { get; set; }

        [Display(Name = "سعر البيع")]
        public double BuyPrice { get; set; }
        [Display(Name ="ملاحطات")]
        public string Notes { get; set; }



        [Display(Name = "اسم المنافسة")]
        public Monafsa Monafsa { get; set; }
        [Display(Name = "المنافسة")]
        public int MonafsaId { get; set; }
        
        [Display(Name = "الوحدة")]
        public int UnitsId { get; set; }
        
        [Display(Name = "الوحدة")]
        public Units Units { get; set; }

    }
}
