using MarketStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly ModelContext _context;

        private readonly IWebHostEnvironment _webHostEnviroment;


        public AdminController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        public IActionResult Index()
        {
            ViewBag.Catecory = _context.CategoryFps.Count();
            ViewBag.Usres=_context.UserFps.Count();
            ViewBag.Store=_context.StoreFps.Count();    
            ViewBag.Product=_context.ProductFps.Count();
            ViewBag.Sale = _context.OrderFps.Sum(x => x.Price * x.TotalPrice);
            int id = 0;
            if (HttpContext.Session.GetInt32("userid") != null)
            {
                ViewBag.id = HttpContext.Session.GetInt32("userid");
                id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();
                ViewBag.Fullname = user.Fullname;
                ViewBag.Email = user.Email;
                ViewBag.Phonenumber = user.Phonenumber;
                ViewBag.image = user.ImagePath;
            }
            var users = _context.UserFps.Where(x => x.UserId == id);

            return View(users);
        }

        public IActionResult Profile1()
        {
            int id=0;
            if (HttpContext.Session.GetInt32("userid") != null)
            {
                ViewBag.id = HttpContext.Session.GetInt32("userid");
                 id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();
                ViewBag.Fullname = user.Fullname;
                ViewBag.Email = user.Email;
                ViewBag.Phonenumber = user.Phonenumber;
                ViewBag.image = user.ImagePath;
            }
            var users = _context.UserFps.Where(x => x.UserId==id);

            return View(users);
        }
        public async Task<IActionResult> Edit(decimal? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var User = await _context.UserFps.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
           
            return View(User);
        }

        // POST: HomeFps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("UserId, imageFile,Email,Fullname,Phonenumber")] UserFp user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (user.imageFile != null)
                    {
                        string wwwrootpath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + user.imageFile.FileName;
                        string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await user.imageFile.CopyToAsync(fileStream);
                        }
                        user.ImagePath = fileName;
                    }
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {


                    throw;

                }
                return RedirectToAction(nameof(Profile1));
            }
            return View(user);
        }
        public IActionResult Total_sale()
        {
           
            var user = _context.UserFps.ToList();
            var order = _context.OrderFps.ToList();
            var orderproduct = _context.OrderProductFps.ToList();
            var producr = _context.ProductFps.ToList();
            var store = _context.StoreFps.ToList();
            var storeproduct = _context.StoreProductFps.ToList();
            var category = _context.CategoryFps.ToList();

            var result = from u in user
                         join o in order on u.UserId equals o.UserId
                         join op in orderproduct on o.OrderId equals op.OrderId
                         join p in producr on op.ProductId equals p.ProductId
                         join sp in storeproduct on p.ProductId equals sp.ProductId
                         join s in store on sp.StoreId equals s.StoreId
                         join cat in category on s.CategoryId equals cat.CatecoryId
                         select new total_sales { user = u, order = o, orderproduct = op, product = p, store = s, storeproduct = sp, category = cat };
           
            var Quantity = _context.OrderFps.Sum(x=>x.TotalPrice);
            
            var totalSale = _context.OrderFps.Count();
            //var Quntity = _context.ProductFps.Sum(x => x.Quantity);

            //ViewBag.Cost = AverageTotalCost/Quntity;
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user11 = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user11.ImagePath;
            ViewBag.Cost = Quantity ;
            ViewBag.TotalOrder = totalSale;
            return View(result);
        }
        [HttpPost]
        public IActionResult Total_sale(DateTime? Sdate, DateTime? Edate)
        {
            var user = _context.UserFps.ToList();
            var order = _context.OrderFps.ToList();
            var orderproduct = _context.OrderProductFps.ToList();
            var producr = _context.ProductFps.ToList();
            var store = _context.StoreFps.ToList();
            var storeproduct = _context.StoreProductFps.ToList();
            var category = _context.CategoryFps.ToList();

            var result = from u in user
                         join o in order on u.UserId equals o.UserId
                         join op in orderproduct on o.OrderId equals op.OrderId
                         join p in producr on op.ProductId equals p.ProductId
                         join sp in storeproduct on p.ProductId equals sp.ProductId
                         join s in store on sp.StoreId equals s.StoreId
                         join cat in category on s.CategoryId equals cat.CatecoryId
                         select new total_sales { user = u, order = o, orderproduct = op, product = p, store = s, storeproduct = sp, category = cat };
            if (Sdate == null && Edate == null)
            {
                var Quantity = _context.OrderFps.Sum(x => x.TotalPrice);
                //var Quntity = _context.ProductFps.Sum(x => x.Quantity);

                //ViewBag.Cost = AverageTotalCost / Quntity;
                int id = (int)HttpContext.Session.GetInt32("userid");
                var user11 = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

                ViewBag.image = user11.ImagePath;
                var totalSale = _context.OrderFps.Count();
                ViewBag.Cost = Quantity * 1;
                ViewBag.Totalsale = totalSale;
                return View(result);
            }
            else if (Sdate != null && Edate == null)
            {
                
                var res = result.Where(x => x.orderproduct. DateOrder.Value.Date == Sdate);
                var Quantity = res.Sum(x=>x.order.TotalPrice);
                var totalSale = res.Count();
                //var Quntity = res.Sum(x => x.product.Quantity);
                //ViewBag.Cost = AverageTotalCost / Quntity;
                int id = (int)HttpContext.Session.GetInt32("userid");
                var user11 = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

                ViewBag.image = user11.ImagePath;
                ViewBag.Cost = Quantity*1;
                ViewBag.Totalsale = totalSale;
                return View(res);
            }

            else if (Sdate == null && Edate != null)
            {
                var res = result.Where(x => x.orderproduct.DateOrder.Value.Date == Edate);
                var Quantity = res.Sum(x => x.order.TotalPrice);
                var totalSale = res.Count();
                //var Quntity = res.Sum(x => x.product.Quantity);
                //ViewBag.Cost = AverageTotalCost / Quntity;
                int id = (int)HttpContext.Session.GetInt32("userid");
                var user11 = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

                ViewBag.image = user11.ImagePath;
                ViewBag.Cost = Quantity*1;
                ViewBag.Totalsale = totalSale;
                return View(res);
            }

            else
            {

                var res = result.Where(x => x.orderproduct.DateOrder.Value.Date >= Sdate && x.orderproduct.DateOrder.Value.Date <= Edate);

                var Quantity = res.Sum(x => x.order.TotalPrice);
                var totalSale = res.Count();
                //var Quntity = res.Sum(x => x.product.Quantity);
                //ViewBag.Cost = AverageTotalCost / Quntity;
                int id = (int)HttpContext.Session.GetInt32("userid");
                var user11 = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

                ViewBag.image = user11.ImagePath;
                ViewBag.Cost = Quantity*1;
                ViewBag.Totalsale = totalSale;
                return View(res);
            }
           
        }

        public IActionResult Search()

        {
            int id = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

            ViewBag.image = user.ImagePath;
            var list = _context.OrderProductFps.Include(p => p.Order).Include(p => p.Product).ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult Search(DateTime? Sdate, DateTime? Edate)
        {

            var list = _context.OrderProductFps.Include(p => p.Order).Include(p => p.Product).ToList();
           
            if (Sdate == null && Edate == null)
            {
                int id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

                ViewBag.image = user.ImagePath;
                return View(list);
            }
            else if(Sdate != null && Edate == null)
            {
                int id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

                ViewBag.image = user.ImagePath;
                var res = list.Where(x=>x.DateOrder.Value.Date == Sdate);
                return View(res);
            }

            else if (Sdate == null && Edate != null)
            {
                int id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

                ViewBag.image = user.ImagePath;
                var res = list.Where(x => x.DateOrder.Value.Date == Edate);
                return View(res);
            }

            else
            {
                int id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();

                ViewBag.image = user.ImagePath;
                var res= list.Where(x => x.DateOrder.Value.Date >= Sdate &&  x.DateOrder.Value.Date <= Edate);
                return View(res);
            }
           
        }
        public IActionResult Logout()
        {
            //userid
            //Delete the Session object.
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");

        }
    }
}