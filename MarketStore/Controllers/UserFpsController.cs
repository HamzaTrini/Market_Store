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
    public class UserFpsController : Controller
    {
        private readonly ModelContext _context;
        
        private readonly IWebHostEnvironment _webHostEnviroment;


        public UserFpsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }
       

        // GET: UserFps
        public async Task<IActionResult> Index()
        {
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user.ImagePath;
            return View(await _context.UserFps.ToListAsync());
        }

        // GET: UserFps/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFp = await _context.UserFps
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userFp == null)
            {
                return NotFound();
            }

            return View(userFp);
        }

        // GET: UserFps/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UserFps/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,Fullname,Email,Password,Username,Phonenumber,ImagePath,imageFile")] UserFp userFp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (userFp.imageFile != null)
        //        {
        //            string wwwrootpath = _webHostEnviroment.WebRootPath;
        //            string fileName = Guid.NewGuid().ToString() + " " + userFp.imageFile.FileName;
        //            string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
        //            using (var fileStream = new FileStream(path, FileMode.Create))
        //            {
        //                await userFp.imageFile.CopyToAsync(fileStream);
        //            }
        //            userFp.ImagePath = fileName;
        //            _context.Add(userFp);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(userFp);
        //}

        //// GET: UserFps/Edit/5
        //public async Task<IActionResult> Edit(decimal? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userFp = await _context.UserFps.FindAsync(id);
        //    if (userFp == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userFp);
        //}

        //// POST: UserFps/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(decimal id, [Bind("UserId,Fullname,Email,Password,Username,Phonenumber,ImagePath,imageFile")] UserFp userFp)
        //{
        //    if (id != userFp.UserId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (userFp.imageFile != null)
        //            {
        //                string wwwrootpath = _webHostEnviroment.WebRootPath;
        //                string fileName = Guid.NewGuid().ToString() + "_" + userFp.imageFile.FileName;
        //                string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
        //                using (var fileStream = new FileStream(path, FileMode.Create))
        //                {
        //                    await userFp.imageFile.CopyToAsync(fileStream);
        //                }
        //                userFp.ImagePath = fileName;
        //            }
        //            _context.Update(userFp);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserFpExists((int)userFp.UserId))
        //            {
        //                return NotFound();
        //            }

        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userFp);
        //}

        // GET: UserFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFp = await _context.UserFps
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userFp == null)
            {
                return NotFound();
            }

            return View(userFp);
        }

        // POST: UserFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var userFp = await _context.UserFps.FindAsync(id);
            _context.UserFps.Remove(userFp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFpExists(decimal id)
        {
            return _context.UserFps.Any(e => e.UserId == id);
        }
    }
}
