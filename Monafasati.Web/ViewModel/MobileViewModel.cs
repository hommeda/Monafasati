using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monafasati.Web.ViewModel
{
    public class MobileViewModel
    {
        public IEnumerable<Statu> status { get; set; }
        public IEnumerable<Engineer> engineers { get; set; }
        public int[] StatusCount { get; set; }
        public int Count { get; set; }
    }
}
