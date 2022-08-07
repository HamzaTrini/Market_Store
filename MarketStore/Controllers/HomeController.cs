using MarketStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
namespace MarketStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvirnment;
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly SignInManager<IdentityUser> signInManager;
        public HomeController(ModelContext context, IWebHostEnvironment webHostEnvirnment, ILogger<HomeController> logger)
        {
            _context = context;
            _webHostEnvirnment = webHostEnvirnment;
            _logger = logger;
        }


        public IActionResult Index()
        {

            var caregory = _context.CategoryFps.ToList();
            var slider = _context.HomeFps.ToList();
            var testimonial = _context.TestimonialFps.ToList();
            var home = Tuple.Create<IEnumerable<CategoryFp>, IEnumerable<HomeFp>, IEnumerable<TestimonialFp>>(caregory, slider, testimonial);

            return View(home);
        }

        public IActionResult About()
        {
            var about = _context.AboutFps.ToList();
            return View(about);
        }
        public IActionResult Contact()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Contact([Bind("ContactId,Email,Taxtmassage")] ContactFp contact)
        {
            if (ModelState.IsValid)
            {

                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Contact));
            }

            return View(contact);
        }
        public IActionResult Profile()
        {
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
                        string wwwrootpath = _webHostEnvirnment.WebRootPath;
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
                return RedirectToAction(nameof(Profile));
            }
            return View(user);
        }
        public IActionResult Testimonial()
        {
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

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Register");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Testimonial([Bind("TestimonialId,UserId,ImagePath,Name,Discription,imageFile")] TestimonialFp testimonialFp)
        {
            if (ModelState.IsValid)
            {
                if (testimonialFp.imageFile != null)
                {
                    string wwwrootpath = _webHostEnvirnment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + testimonialFp.imageFile.FileName;
                    string path = Path.Combine(wwwrootpath + "/Home/images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await testimonialFp.imageFile.CopyToAsync(fileStream);
                    }
                    testimonialFp.ImagePath = fileName;
                    _context.Add(testimonialFp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Testimonial));
                }
            }
            return View(testimonialFp);
        }
        public IActionResult Store(int id)
        {
            var slider = _context.HomeFps.ToList();
            var testimonial = _context.TestimonialFps.ToList();

            var stores = _context.StoreFps.Where(x => x.CategoryId == id);
            var home = Tuple.Create<IEnumerable<StoreFp>, IEnumerable<HomeFp>, IEnumerable<TestimonialFp>>(stores, slider, testimonial);

            return View(home);
        }



        public IActionResult Product(int id)
        {

            var slider = _context.HomeFps.ToList();
            var testimonial = _context.TestimonialFps.ToList();

            var product = _context.ProductFps.ToList();

            var storeProduct = _context.StoreProductFps.Where(x => x.StoreId == id);
            var home2 = Tuple.Create<IEnumerable<HomeFp>, IEnumerable<TestimonialFp>, IEnumerable<ProductFp>, IEnumerable<StoreProductFp>>(slider, testimonial, product, storeProduct);




            return View(home2);
        }
        public IActionResult BuyProduct(int id)
        {



            var order = _context.OrderFps.ToList();
            var product = _context.ProductFps.ToList();
            var orderProduct = _context.OrderProductFps.Where(x => x.Product.ProductId == id);
            var sum = Tuple.Create<IEnumerable<OrderFp>, IEnumerable<ProductFp>, IEnumerable<OrderProductFp>>(order, product, orderProduct);
            return View(sum);

        }


        // POST: OrderProductFps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuyProduct([Bind("OrderId,Price,TotalPrice,UserId,")] OrderFp order)
        {
            int id = 0;
            if (HttpContext.Session.GetInt32("userid") != null)
            {
                ViewBag.id = HttpContext.Session.GetInt32("userid");
                id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id).FirstOrDefault();
                order.UserId = user.UserId;
                if (ModelState.IsValid)
                {
                    _context.Add(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(BuyProduct));
                }
                //var sum = Tuple.Create<IEnumerable<OrderFp>, IEnumerable<UserFp>>(order1, users);
                //tuple
                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Register");
            }

        }
        public IActionResult Cart()
        {
            int id = 0;
            if (HttpContext.Session.GetInt32("userid") != null)
            {
                ViewBag.id = HttpContext.Session.GetInt32("userid");
                id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id);
                //var product = _context.ProductFps.ToList();
                var order = _context.OrderFps.Where(x => x.UserId == id);
                //var orderProduct = _context.OrderProductFps.Where(x => x.Order.UserId == id);
                ViewBag.totalPrice = order.Sum(x => x.Price * x.TotalPrice);
                ViewBag.userid = id;
                //var sum = Tuple.Create<IEnumerable<ProductFp>, IEnumerable<OrderFp>, IEnumerable<OrderProductFp>, IEnumerable<UserFp>>(product, order, orderProduct, user);

                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Register");
            }
        }

        public IActionResult Payment()
        {
            int id = 0;
            if (HttpContext.Session.GetInt32("userid") != null)
            {
                ViewBag.id = HttpContext.Session.GetInt32("userid");
                id = (int)HttpContext.Session.GetInt32("userid");
                var user = _context.UserFps.Where(x => x.UserId == id);
                ViewBag.totalPrice = _context.OrderFps.Where(x => x.UserId == id).Sum(x => x.Price * x.TotalPrice);
                ViewBag.userid = id;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Register");
            }



            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Payment( decimal Cardnumber, decimal Password, decimal totalPrice)
        {
            var card = _context.CardFps.ToList();
            ////CardFp myCard = new CardFp();
            foreach (var item in card) {
                if ((Cardnumber == item.Cardnumber) && (Password == item.Password))
                { if (totalPrice <= item.Palance)
                    {
                        int id = 0;
                        if (HttpContext.Session.GetInt32("userid") != null)
                        {
                            ViewBag.id = HttpContext.Session.GetInt32("userid");
                            id = (int)HttpContext.Session.GetInt32("userid");
                            var user = _context.UserFps.Where(x => x.UserId == id);
                            ViewBag.totalPrice = _context.OrderFps.Where(x => x.UserId == id).Sum(x => x.Price * x.TotalPrice);
                            ViewBag.userid = id;



                            decimal? sum = item.Palance - totalPrice;
                            item.Palance = sum;

                            _context.SaveChanges();
                            MimeMessage message = new MimeMessage();
                            message.From.Add(new MailboxAddress("Mohamad Ali", "mooohamadali931@gmail.com"));
                            message.To.Add(new MailboxAddress("hamza ahmad", "ha8790489@gmail.com"));
                            


                            message.Subject = "Market Store";
                            BodyBuilder body = new BodyBuilder();

                            body.HtmlBody = "<h1> The remaining balance in your account is $ViewBag.totalPrice.00 </h1>";
                            message.Body= body.ToMessageBody();
                            using (var c = new MailKit.Net.Smtp.SmtpClient())
                            {
                                //c.Connect("smtp.gmail.com", 587, false);
                                //c.Authenticate("mooohamadali931@gmail.com", "0787245058");
                                //c.Send(message);
                                //c.Disconnect(true);
                            }

                                return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                      

                        return RedirectToAction(nameof(Payment));
                    }


                }
                else
                {
                    return RedirectToAction(nameof(Payment));


                }
            }
            return View(card);
        }
        
        
       
        public IActionResult Logout()
        {
            //userid
            //Delete the Session object.
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));

        }

        // GET: HomeFps/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.OrderFps
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: HomeFps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var order = await _context.OrderFps.FindAsync(id);
            _context.OrderFps.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Cart));
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
