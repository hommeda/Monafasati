using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monafasati.Data.Services;
using Monafasati.Web.ViewModel;

namespace Monafasati.Web.Controllers
{
    [Authorize]
    public class ArchiveController : Controller
    {
        private readonly IMonafasaData monafasaData;
        private readonly IArchiveData archiveData;

        public ArchiveController(IMonafasaData monafasaData,IArchiveData archiveData)
        {
            this.monafasaData = monafasaData;
            this.archiveData = archiveData;
        }
        public IActionResult Index()
        {
            var ViewModel = new ArchiveViewModel()
            {
                Monafsas = monafasaData.GetAll(),
                StartDate = DateTime.Now.Subtract(new TimeSpan(31, 0, 0, 0)),
                EndDate = DateTime.Now
            };
            
            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Search(ArchiveViewModel archive)
        {
            var ViewModel = new ArchiveViewModel()
            {
                Monafsas = monafasaData.GetByPeriodTime(archive.StartDate,archive.EndDate)
            };


            return View("index", ViewModel);
        }
    }
}
