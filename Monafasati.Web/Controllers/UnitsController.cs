﻿using System;
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
    public class UnitsController : Controller
    {
        private readonly MonafasatiDbContext _context;

        public UnitsController(MonafasatiDbContext context)
        {
            _context = context;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
            return View(await _context.Units.ToListAsync());
        }

        // GET: Units/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Units
                .FirstOrDefaultAsync(m => m.Id == id);
            if (units == null)
            {
                return NotFound();
            }

            return View(units);
        }

        // GET: Units/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Units units)
        {
            if (ModelState.IsValid)
            {
                _context.Add(units);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(units);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Units.FindAsync(id);
            if (units == null)
            {
                return NotFound();
            }
            return View(units);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Units units)
        {
            if (id != units.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(units);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitsExists(units.Id))
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
            return View(units);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Units
                .FirstOrDefaultAsync(m => m.Id == id);
            if (units == null)
            {
                return NotFound();
            }

            return View(units);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var units = await _context.Units.FindAsync(id);
            _context.Units.Remove(units);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitsExists(int id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
    }
}
