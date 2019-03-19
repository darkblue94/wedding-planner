using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wedding.Models;

namespace wedding.Controllers
{
    public class HomeController : Controller
    {   private WeddingContext _context;


    public HomeController(WeddingContext context){
        _context=context;
    }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(ValidateUser NewUser)
        {


            if (ModelState.IsValid)
            {
                Users DBUser = _context.users.SingleOrDefault(u => u.email == NewUser.email);
                if (DBUser != null)
                {
                    ViewBag.Error = "email already exists";
                    return View("Index");
                }



                Users RealUser = new Users();
                RealUser.first_name = NewUser.first_name;
                RealUser.last_name = NewUser.last_name;
                RealUser.email = NewUser.email;
                RealUser.password = NewUser.password;



                _context.users.Add(RealUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", RealUser.UserId);




                return RedirectToAction("About", RealUser.UserId);

            }

            return View("Index");
        }





        [HttpPost]
        [Route("process")]

        public IActionResult Login(string LogEmail, string LogPass)
        {

            Users DBUser = _context.users.SingleOrDefault(u => u.email == LogEmail);
            if (DBUser == null)
            {
                ViewBag.Error = "Invalid Login";
                return View("Index");
            }
            if (LogPass != DBUser.password)
            {
                ViewBag.Error = "Invalid Login";
                return View("Index");

            }

            HttpContext.Session.SetInt32("UserId", DBUser.UserId);

            return View("About");

        }


        [Route("dashboard")]
        public IActionResult About()
        {
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            Users thisUser = _context.users.Where(p => p.UserId == UserId).SingleOrDefault();
            List<Weddings> all_weddings = _context.weddings.ToList();

            ViewBag.wed = all_weddings;

            return View(thisUser);
        }

        [Route("new_wedding")]
        public IActionResult new_wedding()
        {
            ViewData["Message"] = "Your contact page.";

            return View("Wedding");
        }

        public IActionResult register_wedding(string bride , string groom , DateTime date, string adress ){
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            Users thisUser = _context.users.Where(p => p.UserId == UserId).SingleOrDefault();
           DateTime now = DateTime.Now;
           if (date >= now){
            Weddings new_wedding = new Weddings();
            new_wedding.bride=bride;
            new_wedding.groom=groom;
            new_wedding.date=date;
            new_wedding.adress=adress;
           _context.weddings.Add(new_wedding);
           }else{
                              ViewBag.Error= " The Date Must BE Before Today";

           }
           _context.SaveChanges();

           return RedirectToAction("About", thisUser.UserId);


        }

        [Route("/become_guest/{id}")]
        public IActionResult guest(int id ){
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            Users thisUser = _context.users.SingleOrDefault(p => p.UserId == UserId);

            Guest new_guest = new Guest();
            new_guest.UserId=UserId;
            new_guest.WeddingId= id ;
            _context.guests.Add(new_guest);
            _context.SaveChanges();

            return RedirectToAction("About", thisUser);



        }

        [Route("/view/{id}")]
        public IActionResult view_details(int id ){
            Weddings thisWedding = _context.weddings.Include(x => x.guest).ThenInclude(p => p.user).SingleOrDefault(p => p.WeddingId == id);


            return View("Detail", thisWedding);

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
