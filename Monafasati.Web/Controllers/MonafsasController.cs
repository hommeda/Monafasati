using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monafasati.Core.Entity;
using Monafasati.Data;

namespace Monafasati.Web.Controllers
{
    public class MonafsasController : Controller
    {
        private readonly MonafasatiDbContext _context;

        public MonafsasController(MonafasatiDbContext context)
        {
            _context = context;
        }

        // GET: Monafsas
        public async Task<IActionResult> Index()
        {
            var monafasatiDbContext = _context.Monafsas.Include(m => m.Engineer).Include(m => m.Statu);
            return View(await monafasatiDbContext.ToListAsync());
        }

        // GET: Monafsas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monafsa = await _context.Monafsas
                .Include(m => m.Engineer)
                .Include(m => m.Statu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monafsa == null)
            {
                return NotFound();
            }

            return View(monafsa);
        }

        // GET: Monafsas/Create
        public IActionResult Create()
        {
            ViewData["EngineerId"] = new SelectList(_context.Engineers, "Id", "Name");
            ViewData["StatuId"] = new SelectList(_context.Status, "Id", "Name");
            return View();
        }

        // POST: Monafsas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Advertiser,LastDate,Price,StatuId,EngineerId,Sadad")] Monafsa monafsa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monafsa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineerId"] = new SelectList(_context.Engineers, "Id", "Id", monafsa.EngineerId);
            ViewData["StatuId"] = new SelectList(_context.Status, "Id", "Id", monafsa.StatuId);
            return View(monafsa);
        }

        // GET: Monafsas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monafsa = await _context.Monafsas.FindAsync(id);
            if (monafsa == null)
            {
                return NotFound();
            }
            ViewData["EngineerId"] = new SelectList(_context.Engineers, "Id", "Id", monafsa.EngineerId);
            ViewData["StatuId"] = new SelectList(_context.Status, "Id", "Id", monafsa.StatuId);
            return View(monafsa);
        }

        // POST: Monafsas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Advertiser,LastDate,Price,StatuId,EngineerId")] Monafsa monafsa)
        {
            if (id != monafsa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monafsa);
                    await _context.SaveChangesAsync();
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
            ViewData["EngineerId"] = new SelectList(_context.Engineers, "Id", "Id", monafsa.EngineerId);
            ViewData["StatuId"] = new SelectList(_context.Status, "Id", "Id", monafsa.StatuId);
            return View(monafsa);
        }

        // GET: Monafsas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monafsa = await _context.Monafsas
                .Include(m => m.Engineer)
                .Include(m => m.Statu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monafsa == null)
            {
                return NotFound();
            }

            return View(monafsa);
        }

        // POST: Monafsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monafsa = await _context.Monafsas.FindAsync(id);
            _context.Monafsas.Remove(monafsa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),"Home");
        }

        private bool MonafsaExists(int id)
        {
            return _context.Monafsas.Any(e => e.Id == id);
        }
    }
}
