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
    public class TestimonialFpsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;


        public TestimonialFpsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }
        // GET: TestimonialFps
        public async Task<IActionResult> Index()
        {
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user.ImagePath;
            var modelContext = _context.TestimonialFps.Include(t => t.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: TestimonialFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonialFp = await _context.TestimonialFps
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TestimonialId == id);
            if (testimonialFp == null)
            {
                return NotFound();
            }

            return View(testimonialFp);
        }

        // GET: TestimonialFps/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.UserFps, "UserId", "UserId");
            return View();
        }

        // POST: TestimonialFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestimonialId,UserId,ImagePath,Name,Discription,imageFile")] TestimonialFp testimonialFp)
        {
            if (ModelState.IsValid)
            {
                if (testimonialFp.imageFile != null)
                {
                    string wwwrootpath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + testimonialFp.imageFile.FileName;
                    string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await testimonialFp.imageFile.CopyToAsync(fileStream);
                    }
                    testimonialFp.ImagePath = fileName;
                    _context.Add(testimonialFp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["UserId"] = new SelectList(_context.UserFps, "UserId", "UserId", testimonialFp.UserId);
            return View(testimonialFp);
        }

        // GET: TestimonialFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonialFp = await _context.TestimonialFps.FindAsync(id);
            if (testimonialFp == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.UserFps, "UserId", "UserId", testimonialFp.UserId);
            return View(testimonialFp);
        }

        // POST: TestimonialFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("TestimonialId,UserId,ImagePath,Name,Discription,imageFile")] TestimonialFp testimonialFp)
        {
            if (id != testimonialFp.TestimonialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (testimonialFp.imageFile != null)
                    {
                        string wwwrootpath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + testimonialFp.imageFile.FileName;
                        string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await testimonialFp.imageFile.CopyToAsync(fileStream);
                        }
                        testimonialFp.ImagePath = fileName;
                    }
                    _context.Update(testimonialFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialFpExists((int)testimonialFp.TestimonialId))
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
            ViewData["UserId"] = new SelectList(_context.UserFps, "UserId", "UserId", testimonialFp.UserId);
            return View(testimonialFp);
        }

        // GET: TestimonialFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonialFp = await _context.TestimonialFps
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TestimonialId == id);
            if (testimonialFp == null)
            {
                return NotFound();
            }

            return View(testimonialFp);
        }

        // POST: TestimonialFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var testimonialFp = await _context.TestimonialFps.FindAsync(id);
            _context.TestimonialFps.Remove(testimonialFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestimonialFpExists(decimal id)
        {
            return _context.TestimonialFps.Any(e => e.TestimonialId == id);
        }
    }
}
