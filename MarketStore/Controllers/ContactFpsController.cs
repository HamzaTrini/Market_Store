using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketStore.Models;
using Microsoft.AspNetCore.Http;

namespace MarketStore.Controllers
{
    public class ContactFpsController : Controller
    {
        private readonly ModelContext _context;

        public ContactFpsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ContactFps
        public async Task<IActionResult> Index()
        {
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user.ImagePath;
            return View(await _context.ContactFps.ToListAsync());
        }

        // GET: ContactFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactFp = await _context.ContactFps
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactFp == null)
            {
                return NotFound();
            }

            return View(contactFp);
        }

        // GET: ContactFps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,Email,Taxtmassage")] ContactFp contactFp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactFp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactFp);
        }

        // GET: ContactFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactFp = await _context.ContactFps.FindAsync(id);
            if (contactFp == null)
            {
                return NotFound();
            }
            return View(contactFp);
        }

        // POST: ContactFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ContactId,Email,Taxtmassage")] ContactFp contactFp)
        {
            if (id != contactFp.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactFpExists(contactFp.ContactId))
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
            return View(contactFp);
        }

        // GET: ContactFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactFp = await _context.ContactFps
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactFp == null)
            {
                return NotFound();
            }

            return View(contactFp);
        }

        // POST: ContactFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var contactFp = await _context.ContactFps.FindAsync(id);
            _context.ContactFps.Remove(contactFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactFpExists(decimal id)
        {
            return _context.ContactFps.Any(e => e.ContactId == id);
        }
    }
}
