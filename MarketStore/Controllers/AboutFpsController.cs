using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketStore.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MarketStore.Controllers
{
    public class AboutFpsController : Controller
    {
        private readonly ModelContext _context;


        private readonly IWebHostEnvironment _webHostEnviroment;


        public AboutFpsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }


        // GET: AboutFps
        public async Task<IActionResult> Index()
        {
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user.ImagePath;
            return View(await _context.AboutFps.ToListAsync());
        }

        // GET: AboutFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutFp = await _context.AboutFps
                .FirstOrDefaultAsync(m => m.AboutId == id);
            if (aboutFp == null)
            {
                return NotFound();
            }

            return View(aboutFp);
        }

        // GET: AboutFps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AboutFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutId,ImagePath,Discription,imageFile")] AboutFp aboutFp)
        {
            if (ModelState.IsValid)
            {
                if (aboutFp.imageFile != null)
                {
                    string wwwrootpath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + aboutFp.imageFile.FileName;
                    string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await aboutFp.imageFile.CopyToAsync(fileStream);
                    }
                    aboutFp.ImagePath = fileName;
                    _context.Add(aboutFp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(aboutFp);
        }

        // GET: AboutFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutFp = await _context.AboutFps.FindAsync(id);
            if (aboutFp == null)
            {
                return NotFound();
            }
            return View(aboutFp);
        }

        // POST: AboutFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("AboutId,ImagePath,Discription,imageFile")] AboutFp aboutFp)
        {
            if (id != aboutFp.AboutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (aboutFp.imageFile != null)
                    {
                        string wwwrootpath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + aboutFp.imageFile.FileName;
                        string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await aboutFp.imageFile.CopyToAsync(fileStream);
                        }
                        aboutFp.ImagePath = fileName;
                    }
                    _context.Update(aboutFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutFpExists((int)aboutFp.AboutId))
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
            return View(aboutFp);
        }

        // GET: AboutFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutFp = await _context.AboutFps
                .FirstOrDefaultAsync(m => m.AboutId == id);
            if (aboutFp == null)
            {
                return NotFound();
            }

            return View(aboutFp);
        }

        // POST: AboutFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var aboutFp = await _context.AboutFps.FindAsync(id);
            _context.AboutFps.Remove(aboutFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutFpExists(decimal id)
        {
            return _context.AboutFps.Any(e => e.AboutId == id);
        }
    }
}
