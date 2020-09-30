using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Monafasati.Core.Entity
{
   public class Units
    {
        public int Id { get; set; }

        [Display(Name ="أسم الوحدة")]
        public string Name { get; set; }
    }
}
