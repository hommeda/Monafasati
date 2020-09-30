using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Monafasati.Core.Entity;
using Monafasati.Data;
using Monafasati.Web.Models;
using Monafasati.Web.ViewModel;

namespace Monafasati.Web.Controllers
{
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class HomeController : Controller
    {

        private readonly MonafasatiDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(MonafasatiDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List()
        {
            var Monafsas = await dbContext.Monafsas
                .Include(m => m.Statu)
                .Include(m=>m.Engineer)
                .ToListAsync();
            return View(Monafsas);
        }

        public IActionResult New()
        {
            ViewData["EngineerId"] = new SelectList(dbContext.Engineers, "Id", "Name");
            ViewData["StatuId"] = new SelectList(dbContext.Status, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(MonafastViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                string uniqueFileName = UploadedFile(model);

                Monafsa monafsa = new Monafsa
                {
                    Name=model.Name,
                    EngineerId=model.EngineerId,
                    LastDate=model.LastDate,
                    PdfFile=uniqueFileName,
                    Advertiser=model.Advertiser,
                    Note=model.Note,
                    Price=model.Price,
                    Sadad=model.Sadad,
                    StatuId=model.StatuId
                };
                dbContext.Add(monafsa);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monafsa = await dbContext.Monafsas
                .Include(m => m.Engineer)
                .Include(m => m.Statu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monafsa == null)
            {
                return NotFound();
            }

            return View(monafsa);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monafsa = await dbContext.Monafsas.FindAsync(id);
            if (monafsa == null)
            {
                return NotFound();
            }
            ViewData["EngineerId"] = new SelectList(dbContext.Engineers, "Id", "Name", monafsa.EngineerId);
            ViewData["StatuId"] = new SelectList(dbContext.Status, "Id", "Name", monafsa.StatuId);
            return View(monafsa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Advertiser,LastDate,Price,StatuId,EngineerId,Sadad,Note")] Monafsa monafsa)
        {
            if (id != monafsa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var InDbMonafsa = dbContext.Monafsas.SingleOrDefault(c => c.Id == monafsa.Id);
                    InDbMonafsa.Advertiser = monafsa.Advertiser;
                    InDbMonafsa.EngineerId = monafsa.EngineerId;
                    InDbMonafsa.LastDate = monafsa.LastDate;
                    InDbMonafsa.Name = monafsa.Name;
                    InDbMonafsa.Note = monafsa.Note;
                    InDbMonafsa.Price = monafsa.Price;
                    InDbMonafsa.Sadad = monafsa.Sadad;
                    InDbMonafsa.StatuId = monafsa.StatuId;
                    await dbContext.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineerId"] = new SelectList(dbContext.Engineers, "Id", "Name", monafsa.EngineerId);
            ViewData["StatuId"] = new SelectList(dbContext.Status, "Id", "Name", monafsa.StatuId);
            return View(monafsa);
        }

        private string UploadedFile(MonafastViewModel model)
        {
            string uniqueFileName = null;

            if (model.PdfFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PdfFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PdfFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private bool MonafsaExists(int id)
        {
            return dbContext.Monafsas.Any(e => e.Id == id);
        }

    }
}
