﻿using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monafasati.Web.ViewModel
{
    public class ItemsViewModel
    {
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
        [Display(Name = "ملاحطات")]
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
