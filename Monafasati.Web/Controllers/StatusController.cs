using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monafasati.Core.Entity;
using Monafasati.Data;

namespace Monafasati.Web.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        private readonly MonafasatiDbContext _context;

        public StatusController(MonafasatiDbContext context)
        {
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            return View(await _context.Status.ToListAsync());
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statu = await _context.Status
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statu == null)
            {
                return NotFound();
            }

            return View(statu);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Statu statu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statu);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statu = await _context.Status.FindAsync(id);
            if (statu == null)
            {
                return NotFound();
            }
            return View(statu);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Statu statu)
        {
            if (id != statu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatuExists(statu.Id))
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
            return View(statu);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statu = await _context.Status
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statu == null)
            {
                return NotFound();
            }

            return View(statu);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statu = await _context.Status.FindAsync(id);
            _context.Status.Remove(statu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatuExists(int id)
        {
            return _context.Status.Any(e => e.Id == id);
        }
    }
}
