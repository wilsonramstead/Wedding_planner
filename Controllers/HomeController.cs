using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using wedding_planner.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace wedding_planner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("processregister")]
        public IActionResult ProcessRegister(User user)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    int ID = user.UserID;
                    HttpContext.Session.SetInt32("userID", ID);
                    return RedirectToAction("Dashboard", new{ID = ID});
                }
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost("processlogin")]
        public IActionResult ProcessLogin(UserLogin userSubmission)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.logEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("logEmail", "Invalid Email/Password");
                    return View("Index");
                }
                
                var hasher = new PasswordHasher<UserLogin>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    return View("Index");
                }
                else
                {
                    int ID = userInDb.UserID;
                    HttpContext.Session.SetInt32("userID", ID);
                    return RedirectToAction("Dashboard", new{ID = ID});
                }
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("Dashboard/{ID:int}")]
        public IActionResult Dashboard(int ID)
        {
            System.Console.WriteLine("ID: " + ID);
            if(HttpContext.Session.GetInt32("userID") == ID)
            {
                ViewBag.ID = ID;
                User CurrentUser = dbContext.Users.FirstOrDefault(u => u.UserID == ID);
                ViewBag.CurrentUser = CurrentUser;
                List<Wedding> allWeddings = dbContext.Weddings
                .Include(w => w.Weddings)
                .ThenInclude(e => e.User)
                .ToList();

                List<User> allUsers = dbContext.Users
                .Include(u => u.Users)
                .ThenInclude(e => e.Wedding)
                .ToList();
                System.Console.WriteLine(allUsers);
                ViewBag.allUsers = allUsers;

                return View("Dashboard", allWeddings);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("createwedding/{ID:int}")]
        public IActionResult CreateWedding(int ID)
        {
            ViewBag.ID = ID;
            return View("CreateWedding");
        }

        [HttpPost("processwedding/{ID:int}")]
        public IActionResult ProcessWedding(Wedding wedding, int ID)
        {
            if(ModelState.IsValid)
            {
                DateTime today = DateTime.Today;
                if(wedding.Date < today)
                {
                    ModelState.AddModelError("Date", "Date must be in the future!");
                    return View("CreateWedding");
                }
                else
                {
                    dbContext.Weddings.Add(wedding);
                    wedding.CreatorID = ID;
                    dbContext.SaveChanges();
                    int wedID = wedding.WeddingID;
                    return RedirectToAction("ShowWedding", new{wedID = wedID});
                }
            }
            else
            {
                return View("CreateWedding");
            }
        }

        [HttpGet("showwedding/{wedID:int}")]
        public IActionResult ShowWedding(int wedID)
        {
            Wedding wedding = dbContext.Weddings
            .Include(w => w.Weddings)
            .ThenInclude(e => e.User)
            .FirstOrDefault(w => w.WeddingID == wedID);

            List<User> allUsers = dbContext.Users
            .Include(u => u.Users)
            .ThenInclude(e => e.Wedding)
            .ToList();

            int? userid = HttpContext.Session.GetInt32("userID");
            int userID = userid ?? default(int);
            ViewBag.userID = userID;
            return View("ShowWedding", wedding);
        }

        [HttpGet("processevent/{wedID:int}")]
        public IActionResult ProcessEvent(Event item, int wedID)
        {
            int? id = HttpContext.Session.GetInt32("userID");
            int ID = id ?? default(int);

            item.UserID = ID;
            item.WeddingID = wedID;

            dbContext.Event.Add(item);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard", new{ID = ID});
        }

        [HttpGet("undoprocessevent/{wedID:int}")]
        public IActionResult UndoProcessEvent(Event item, int wedID)
        {
            int? id = HttpContext.Session.GetInt32("userID");
            int ID = id ?? default(int);
            Event Event = dbContext.Event.Where(w => w.WeddingID == wedID).FirstOrDefault(u => u.UserID == ID);

            dbContext.Event.Remove(Event);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard", new{ID = ID});
        }


        [HttpGet("delete/{wedID:int}")]
        public IActionResult Delete(int wedID)
        {
            int? id = HttpContext.Session.GetInt32("userID");
            int ID = id ?? default(int);

            Wedding wedding = dbContext.Weddings
            .FirstOrDefault(w => w.WeddingID == wedID);

            dbContext.Weddings.Remove(wedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard", new{ID = ID});
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}
