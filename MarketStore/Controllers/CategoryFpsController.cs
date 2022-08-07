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
    public class CategoryFpsController : Controller
    {
        private readonly ModelContext _context;

        
        private readonly IWebHostEnvironment _webHostEnviroment;
       

        public CategoryFpsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        // GET: CategoryFps
        public async Task<IActionResult> Index()
        {
            //ViewBag.id = HttpContext.Session.GetInt32("userid");
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();
            
            ViewBag.image = user.ImagePath;
            return View(await _context.CategoryFps.ToListAsync());
        }

        // GET: CategoryFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryFp = await _context.CategoryFps
                .FirstOrDefaultAsync(m => m.CatecoryId == id);
            if (categoryFp == null)
            {
                return NotFound();
            }

            return View(categoryFp);
        }

        // GET: CategoryFps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatecoryId,Name,imageFile")] CategoryFp categoryFp)
        {
            if (ModelState.IsValid)
            {
                if (categoryFp.imageFile != null)
                {
                    string wwwrootpath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + categoryFp.imageFile.FileName;
                    string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await categoryFp.imageFile.CopyToAsync(fileStream);
                    }
                    categoryFp.ImagePath = fileName;
                    _context.Add(categoryFp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(categoryFp);
        }

        // GET: CategoryFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryFp = await _context.CategoryFps.FindAsync(id);
            if (categoryFp == null)
            {
                return NotFound();
            }
            return View(categoryFp);
        }

        // POST: CategoryFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CatecoryId,Name,imageFile")] CategoryFp categoryFp)
        {
            if (id != categoryFp.CatecoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (categoryFp.imageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + categoryFp.imageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/Home/images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await categoryFp.imageFile.CopyToAsync(fileStream);
                        }
                        categoryFp.ImagePath = fileName;
                    }
                    _context.Update(categoryFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryFpExists((int)categoryFp.CatecoryId))
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
            return View(categoryFp);
        }


        // GET: CategoryFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryFp = await _context.CategoryFps
                .FirstOrDefaultAsync(m => m.CatecoryId == id);
            if (categoryFp == null)
            {
                return NotFound();
            }

            return View(categoryFp);
        }

        // POST: CategoryFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var categoryFp = await _context.CategoryFps.FindAsync(id);
            _context.CategoryFps.Remove(categoryFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryFpExists(decimal id)
        {
            return _context.CategoryFps.Any(e => e.CatecoryId == id);
        }
    }
}
