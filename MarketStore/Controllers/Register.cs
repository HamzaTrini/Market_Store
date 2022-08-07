using MarketStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketStore.Controllers
{
    public class Register : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvirnment;
       

       public Register(ModelContext context, IWebHostEnvironment webHostEnvirnment)
        {
            _context = context;
            _webHostEnvirnment = webHostEnvirnment;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Fullname,Email,Password,Username,Phonenumber,ImagePath,imageFile")] UserFp user, string Username, decimal? Password)
        {
            if (ModelState.IsValid)
            {
                if (user.imageFile != null)
                {
                    string wwwrootpath = _webHostEnvirnment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + user.imageFile.FileName;
                    string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await user.imageFile.CopyToAsync(fileStream);
                    }
                    user.ImagePath = fileName;
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    LoginFp loginFp = new LoginFp();
                    loginFp.Name = Username;
                    loginFp.Password = Password;
                    loginFp.RoleId = 2;
                    loginFp.UserId = user.UserId;
                    _context.Add(loginFp);
                    await _context.SaveChangesAsync();


                    return RedirectToAction(nameof(Login));
                }
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([Bind("Name", "Password")] LoginFp userLogin)
        {
            var check = _context.LoginFps.Where(x => x.Name == userLogin.Name && x.Password == userLogin.Password).SingleOrDefault();

            if (check != null)
            {
                switch (check.RoleId)
                {
                    case 1:
                        HttpContext.Session.SetInt32("userid", (int)check.UserId);
                        return RedirectToAction("Index", "Admin");

                    case 2:
                        HttpContext.Session.SetInt32("userid", (int)check.UserId);
                        return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }
    }
}
