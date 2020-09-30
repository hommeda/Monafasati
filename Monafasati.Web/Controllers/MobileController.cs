using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Monafasati.Core.Entity;
using Monafasati.Data;
using Monafasati.Data.Services;
using Monafasati.Web.ViewModel;

namespace Monafasati.Web.Controllers
{
    public class MobileController : Controller
    {
        private readonly ILogger _loger;
        private readonly IStatuData data;
        private readonly IMonafasaData monafasaData;
        private readonly IEngineerData engineerData;
        private readonly MonafasatiDbContext context;

        public MobileController(ILogger<MobileController> loger, IStatuData data,IMonafasaData monafasaData,IEngineerData engineerData,MonafasatiDbContext context)
        {
            this._loger = loger;
            this.data = data;
            this.monafasaData = monafasaData;
            this.engineerData = engineerData;
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "منافساتي";
            var Count = 0;
            var viewModel = new MobileViewModel() { StatusCount=new int[100]};
                viewModel.status= data.GetAll();
            viewModel.engineers = engineerData.GetAll();
            foreach (var item in viewModel.status)
            {
                viewModel.StatusCount[Count] = monafasaData.GetByStatu(item.Id).Count();
                Count++;
            }
            viewModel.Count = 0;
            return View(viewModel);
        }
        public IActionResult List(int Id)
        {
            
            var viewModelMonafasa = monafasaData.GetByStatu(Id);   
            return View(viewModelMonafasa);
        }
        public IActionResult ListByEng(int Id)
        {

            var viewModelMonafasa = monafasaData.GetByEngineer(Id);
            return View("List",viewModelMonafasa);
        }
        public IActionResult Details(int id)
        {
            var ViewModelMonafsaDetails = monafasaData.GetMonafasDetails(id);
            if (ViewModelMonafsaDetails == null)
                return NotFound();
            return View(ViewModelMonafsaDetails);
        }
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var viewModelMonafasa = await monafasaData.Edit(id);
            ViewData["EngineerId"] = new SelectList(context.Engineers, "Id", "Name",viewModelMonafasa.EngineerId);
            ViewData["StatuId"] = new SelectList(context.Status, "Id", "Name", viewModelMonafasa.StatuId);
            return View(viewModelMonafasa);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Advertiser,LastDate,Price,StatuId,EngineerId,Sadad,Note,PdfFile")] Monafsa monafsa)
        {
            if (id != monafsa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(monafsa);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonafsaExists(monafsa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details),new {id=monafsa.Id });
            }
            ViewData["EngineerId"] = new SelectList(context.Engineers, "Id", "Name", monafsa.EngineerId);
            ViewData["StatuId"] = new SelectList(context.Status, "Id", "Name", monafsa.StatuId);
            return View(monafsa);
        }
        private bool MonafsaExists(int id)
        {
            return context.Monafsas.Any(e => e.Id == id);
        }

    }
}
