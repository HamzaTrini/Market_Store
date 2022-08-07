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
    public class HomeFpsController : Controller
    {
        private readonly ModelContext _context;

        private readonly IWebHostEnvironment _webHostEnviroment;


        public HomeFpsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        // GET: HomeFps
        public async Task<IActionResult> Index()
        {
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user.ImagePath;
            return View(await _context.HomeFps.ToListAsync());
        }

        // GET: HomeFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeFp = await _context.HomeFps
                .FirstOrDefaultAsync(m => m.HomeId == id);
            if (homeFp == null)
            {
                return NotFound();
            }

            return View(homeFp);
        }

        // GET: HomeFps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeId,Discription,ImagePath,imageFile")] HomeFp homeFp)
        {
            if (ModelState.IsValid)
            {
                if (homeFp.imageFile != null)
                {
                    string wwwrootpath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + homeFp.imageFile.FileName;
                    string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await homeFp.imageFile.CopyToAsync(fileStream);
                    }
                    homeFp.ImagePath = fileName;
                    _context.Add(homeFp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(homeFp);
        }

        // GET: HomeFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeFp = await _context.HomeFps.FindAsync(id);
            if (homeFp == null)
            {
                return NotFound();
            }
            return View(homeFp);
        }

        // POST: HomeFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("HomeId,Discription,ImagePath,imageFile")] HomeFp homeFp)
        {
            if (id != homeFp.HomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (homeFp.imageFile != null)
                    {
                        string wwwrootpath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + homeFp.imageFile.FileName;
                        string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await homeFp.imageFile.CopyToAsync(fileStream);
                        }
                        homeFp.ImagePath = fileName;
                    }
                    _context.Update(homeFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeFpExists((int)homeFp.HomeId))
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
            return View(homeFp);
        }

        // GET: HomeFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeFp = await _context.HomeFps
                .FirstOrDefaultAsync(m => m.HomeId == id);
            if (homeFp == null)
            {
                return NotFound();
            }

            return View(homeFp);
        }

        // POST: HomeFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var homeFp = await _context.HomeFps.FindAsync(id);
            _context.HomeFps.Remove(homeFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeFpExists(decimal id)
        {
            return _context.HomeFps.Any(e => e.HomeId == id);
        }
    }
}
