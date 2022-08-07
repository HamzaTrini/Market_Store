using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketStore.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MarketStore.Controllers
{
    public class StoreFpsController : Controller
    {
        private readonly ModelContext _context;

        private readonly IWebHostEnvironment _webHostEnviroment;


        public StoreFpsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }


        // GET: StoreFps
        public async Task<IActionResult> Index()
        {
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user.ImagePath;
            var modelContext = _context.StoreFps.Include(s => s.Category);
            return View(await modelContext.ToListAsync());
        }

        // GET: StoreFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeFp = await _context.StoreFps
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (storeFp == null)
            {
                return NotFound();
            }

            return View(storeFp);
        }

        // GET: StoreFps/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CategoryFps, "CatecoryId", "CatecoryId");
            return View();
        }

        // POST: StoreFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,Name,ImagePath,CategoryId,Totalsale,Obtainsfinancial,imageFile")] StoreFp storeFp)
        {
            if (ModelState.IsValid)
            {
                if (storeFp.imageFile != null)
                {
                    string wwwrootpath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + storeFp.imageFile.FileName;
                    string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await storeFp.imageFile.CopyToAsync(fileStream);
                    }
                    storeFp.ImagePath = fileName;
                    _context.Add(storeFp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryFps, "CatecoryId", "CatecoryId", storeFp.CategoryId);
            return View(storeFp);
        }

        // GET: StoreFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeFp = await _context.StoreFps.FindAsync(id);
            if (storeFp == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryFps, "CatecoryId", "CatecoryId", storeFp.CategoryId);
            return View(storeFp);
        }

        // POST: StoreFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("StoreId,Name,ImagePath,CategoryId,Totalsale,Obtainsfinancial,imageFile")] StoreFp storeFp)
        {
            if (id != storeFp.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (storeFp.imageFile != null)
                    {
                        string wwwrootpath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + storeFp.imageFile.FileName;
                        string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await storeFp.imageFile.CopyToAsync(fileStream);
                        }
                        storeFp.ImagePath = fileName;
                    }
                    _context.Update(storeFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreFpExists((int)storeFp.StoreId))
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
            ViewData["CategoryId"] = new SelectList(_context.CategoryFps, "CatecoryId", "CatecoryId", storeFp.CategoryId);
            return View(storeFp);
        }

        // GET: StoreFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeFp = await _context.StoreFps
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (storeFp == null)
            {
                return NotFound();
            }

            return View(storeFp);
        }

        // POST: StoreFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var storeFp = await _context.StoreFps.FindAsync(id);
            _context.StoreFps.Remove(storeFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreFpExists(decimal id)
        {
            return _context.StoreFps.Any(e => e.StoreId == id);
        }
    }
}
