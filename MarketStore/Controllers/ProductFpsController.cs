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
    public class ProductFpsController : Controller
    {
        private readonly ModelContext _context;


        private readonly IWebHostEnvironment _webHostEnviroment;


        public ProductFpsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        // GET: ProductFps
        public async Task<IActionResult> Index()
        {
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user.ImagePath;
            return View(await _context.ProductFps.ToListAsync());
        }

        // GET: ProductFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFp = await _context.ProductFps
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productFp == null)
            {
                return NotFound();
            }

            return View(productFp);
        }

        // GET: ProductFps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Price,ImagePath,Quantity,imageFile")] ProductFp productFp)
        {
            if (ModelState.IsValid)
            {
                if (productFp.imageFile != null)
                {
                    string wwwrootpath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + productFp.imageFile.FileName;
                    string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await productFp.imageFile.CopyToAsync(fileStream);
                    }
                    productFp.ImagePath = fileName;
                    _context.Add(productFp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(productFp);
        }

        // GET: ProductFps/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFp = await _context.ProductFps.FindAsync(id);
            if (productFp == null)
            {
                return NotFound();
            }
            return View(productFp);
        }

        // POST: ProductFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ProductId,Name,Price,ImagePath,Quantity,imageFile")] ProductFp productFp)
        {
            if (id != productFp.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (productFp.imageFile != null)
                    {
                        string wwwrootpath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + productFp.imageFile.FileName;
                        string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await productFp.imageFile.CopyToAsync(fileStream);
                        }
                        productFp.ImagePath = fileName;
                    }
                    _context.Update(productFp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductFpExists((int)productFp.ProductId))
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
            return View(productFp);
        }

        // GET: ProductFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFp = await _context.ProductFps
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productFp == null)
            {
                return NotFound();
            }

            return View(productFp);
        }

        // POST: ProductFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var productFp = await _context.ProductFps.FindAsync(id);
            _context.ProductFps.Remove(productFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductFpExists(decimal id)
        {
            return _context.ProductFps.Any(e => e.ProductId == id);
        }
    }
}
