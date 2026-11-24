using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstructorInformationsSystem.Data;
using InstructorInformationsSystem.Models;

namespace InstructorInformationsSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("AdminName"));
        }

        // GET: Registration Page
        [HttpGet]
        public IActionResult Register()
        {
            if (IsLoggedIn()) return RedirectToAction("Index", "Instructor");
            return View();
        }

        // POST: Process Registration Form using Database
        [HttpPost]
        public async Task<IActionResult> Register(Admin model)
        {
            if (IsLoggedIn()) return RedirectToAction("Index", "Instructor");

            if (ModelState.IsValid)
            {
                if (await _context.Admins.AnyAsync(a => a.Email == model.Email))
                {
                    ViewBag.Alert = "An account with this email already exists.";
                    return View(model);
                }

                _context.Admins.Add(model);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Registration successful! Please login.";
                return RedirectToAction("Login");
            }

            ViewBag.Alert = "Invalid inputs! Please check all required fields.";
            return View(model);
        }

        // GET: Login Page
        [HttpGet]
        public IActionResult Login()
        {
            if (IsLoggedIn()) return RedirectToAction("Index", "Instructor");
            return View();
        }

        // POST: Process Login Form using Database
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (IsLoggedIn()) return RedirectToAction("Index", "Instructor");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Alert = "Please fill in both email and password.";
                return View();
            }

            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
            if (admin != null)
            {
                HttpContext.Session.SetString("AdminName", $"{admin.FirstName} {admin.LastName}");
                return RedirectToAction("Index", "Instructor");
            }

            ViewBag.Alert = "Invalid credentials entered. Please check your email and password.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}