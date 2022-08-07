using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketStore.Models;

namespace MarketStore.Controllers
{
    public class StoreProductFpsController : Controller
    {
        private readonly ModelContext _context;

        public StoreProductFpsController(ModelContext context)
        {
            _context = context;
        }

        // GET: StoreProductFps
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.StoreProductFps.Include(s => s.Product).Include(s => s.Store);
            return View(await modelContext.ToListAsync());
        }

        // GET: StoreProductFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeProductFp = await _context.StoreProductFps
                .Include(s => s.Product)
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.StoreProductId == id);
            if (storeProductFp == null)
            {
                return NotFound();
            }

            return View(storeProductFp);
        }

        // GET: StoreProductFps/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.ProductFps, "ProductId", "Name");
            ViewData["StoreId"] = new SelectList(_context.StoreFps, "StoreId", "Name");
            return View();
        }

        // POST: StoreProductFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreProductId,StoreId,ProductId")] StoreProductFp storeProductFp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeProductFp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.ProductFps, "ProductId", "ProductId", storeProductFp.ProductId);
            ViewData["StoreId"] = new SelectList(_context.StoreFps, "StoreId", "StoreId", storeProductFp.StoreId);
            return View(storeProductFp);
        }

        // GET: StoreProductFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeProductFp = await _context.StoreProductFps.FindAsync(id);
            if (storeProductFp == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.ProductFps, "ProductId", "Name", storeProductFp.ProductId);
            ViewData["StoreId"] = new SelectList(_context.StoreFps, "StoreId", "Name", storeProductFp.StoreId);
            return View(storeProductFp);
        }

        // POST: StoreProductFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("StoreProductId,StoreId,ProductId")] StoreProductFp storeProductFp)
        {
            if (id != storeProductFp.StoreProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeProductFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreProductFpExists(storeProductFp.StoreProductId))
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
            ViewData["ProductId"] = new SelectList(_context.ProductFps, "ProductId", "ProductId", storeProductFp.ProductId);
            ViewData["StoreId"] = new SelectList(_context.StoreFps, "StoreId", "StoreId", storeProductFp.StoreId);
            return View(storeProductFp);
        }

        // GET: StoreProductFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeProductFp = await _context.StoreProductFps
                .Include(s => s.Product)
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.StoreProductId == id);
            if (storeProductFp == null)
            {
                return NotFound();
            }

            return View(storeProductFp);
        }

        // POST: StoreProductFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var storeProductFp = await _context.StoreProductFps.FindAsync(id);
            _context.StoreProductFps.Remove(storeProductFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreProductFpExists(decimal id)
        {
            return _context.StoreProductFps.Any(e => e.StoreProductId == id);
        }
    }
}
