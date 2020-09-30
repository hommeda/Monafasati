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
using Monafasati.Data.ModelDto;
using Monafasati.Data.Services;
using Monafasati.Web.ViewModel;

namespace Monafasati.Web.Controllers
{
 [Authorize]
    public class ItemsController : Controller
    {
        private readonly MonafasatiDbContext _context;
        private readonly IItemData itemData;
        private readonly IMonafasaData monafasaData;

        public ItemsController(MonafasatiDbContext context,IItemData itemData,IMonafasaData monafasaData)
        {
            _context = context;
            this.itemData = itemData;
            this.monafasaData = monafasaData;
        }

        // GET: Items
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Index()
        {
            var monafasatiDbContext = _context.Items.Include(i => i.Monafsa).Include(i => i.Units);
            return View(await monafasatiDbContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Monafsa)
                .Include(i => i.Units)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
     
        public IActionResult Create(int id)

        {

            ViewData["MonafsaId"] = new SelectList(_context.Monafsas, "Id", "Name");
            ViewData["UnitsId"] = new SelectList(_context.Units, "Id", "Name");
            var monafsa = monafasaData.GetMonafasDetails(id);
            var ViewModelItem = new ItemDto { MonafsaId = id,Monafsa=monafsa };
            return View(ViewModelItem);
        }


        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ItemCode,Name,Count,Price,BuyPrice,MonafsaId,UnitsId")] ItemDto item)
        {
            if (ModelState.IsValid)
            {


                if (itemData.Create(item))



                    return RedirectToAction("Monafsa",new {id=item.MonafsaId });
                return NotFound();
            }
            ViewData["MonafsaId"] = new SelectList(_context.Monafsas, "Id", "Name", item.MonafsaId);
            ViewData["UnitsId"] = new SelectList(_context.Units, "Id", "Name", item.UnitsId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.Include(c=>c.Monafsa)
                .FirstOrDefaultAsync(c=>c.Id==id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["MonafsaId"] = new SelectList(_context.Monafsas, "Id", "Name", item.MonafsaId);
            ViewData["UnitsId"] = new SelectList(_context.Units, "Id", "Name", item.UnitsId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemCode,Name,Count,Price,BuyPrice,MonafsaId,UnitsId")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Monafsa),new {id=item.MonafsaId });
            }
            ViewData["MonafsaId"] = new SelectList(_context.Monafsas, "Id", "Name", item.MonafsaId);
            ViewData["UnitsId"] = new SelectList(_context.Units, "Id", "Name", item.UnitsId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Monafsa)
                .Include(i => i.Units)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Monafsa),new {id=item.MonafsaId });
        }
        public IActionResult Monafsa(int Id)
        {
            var MonafsaItems = itemData.GetItemsByMonafsaId(Id);
            if (MonafsaItems == null)
                return NotFound();
          
                ViewData["MonafsaId"] = Id;
          
            return View(MonafsaItems);
        }
        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
