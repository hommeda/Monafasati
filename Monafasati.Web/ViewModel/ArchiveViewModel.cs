using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monafasati.Web.ViewModel
{
    public class ArchiveViewModel
    {
        public IEnumerable<Monafsa> Monafsas { get; set; }

        [Display(Name = "تاريخ البداية")]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name ="تاريخ النهاية")]
        public DateTime EndDate { get; set; }
    }
}
