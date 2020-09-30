using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Monafasati.Core.Entity
{
    public class Statu
    {
        public int Id { get; set; }

        [Display(Name ="الاسم")]
        public string Name { get; set; }
    }

}
