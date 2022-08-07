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
    public class OrderProductFpsController : Controller
    {
        private readonly ModelContext _context;

        public OrderProductFpsController(ModelContext context)
        {
            _context = context;
        }

        // GET: OrderProductFps
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.OrderProductFps.Include(o => o.Order).Include(o => o.Product);
            return View(await modelContext.ToListAsync());
        }

        // GET: OrderProductFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderProductFp = await _context.OrderProductFps
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderProductId == id);
            if (orderProductFp == null)
            {
                return NotFound();
            }

            return View(orderProductFp);
        }

        // GET: OrderProductFps/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.OrderFps, "OrderId", "StoreName");
            ViewData["ProductId"] = new SelectList(_context.ProductFps, "ProductId", "Name");
            return View();
        }

        // POST: OrderProductFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderProductId,OrderId,ProductId,Cart,DateOrder")] OrderProductFp orderProductFp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderProductFp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.OrderFps, "OrderId", "StoreName", orderProductFp.OrderId);
            ViewData["ProductId"] = new SelectList(_context.ProductFps, "ProductId", "Name", orderProductFp.ProductId);
            return View(orderProductFp);
        }

        // GET: OrderProductFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderProductFp = await _context.OrderProductFps.FindAsync(id);
            if (orderProductFp == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.OrderFps, "OrderId", "OrderId", orderProductFp.OrderId);
            ViewData["ProductId"] = new SelectList(_context.ProductFps, "ProductId", "ProductId", orderProductFp.ProductId);
            return View(orderProductFp);
        }

        // POST: OrderProductFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("OrderProductId,OrderId,ProductId,Cart,DateOrder")] OrderProductFp orderProductFp)
        {
            if (id != orderProductFp.OrderProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderProductFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderProductFpExists(orderProductFp.OrderProductId))
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
            ViewData["OrderId"] = new SelectList(_context.OrderFps, "OrderId", "OrderId", orderProductFp.OrderId);
            ViewData["ProductId"] = new SelectList(_context.ProductFps, "ProductId", "ProductId", orderProductFp.ProductId);
            return View(orderProductFp);
        }

        // GET: OrderProductFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderProductFp = await _context.OrderProductFps
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderProductId == id);
            if (orderProductFp == null)
            {
                return NotFound();
            }

            return View(orderProductFp);
        }

        // POST: OrderProductFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var orderProductFp = await _context.OrderProductFps.FindAsync(id);
            _context.OrderProductFps.Remove(orderProductFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderProductFpExists(decimal id)
        {
            return _context.OrderProductFps.Any(e => e.OrderProductId == id);
        }
    }
}
