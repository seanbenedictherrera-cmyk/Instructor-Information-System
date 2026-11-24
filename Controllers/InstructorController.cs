using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstructorInformationsSystem.Data;
using InstructorInformationsSystem.Models;

namespace InstructorInformationsSystem.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("AdminName"));
        }

        // GET: Fetch list from the SQLite Database
        public async Task<IActionResult> Index()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");
            var instructors = await _context.Instructors.ToListAsync();
            return View(instructors);
        }

        // GET: Details from Database
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");
            var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.InstructorID == id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }

        // GET: Create View
        [HttpGet]
        public IActionResult Create()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Save New Instructor to Database
        [HttpPost]
        public async Task<IActionResult> Create(Instructor instructor)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                if (await _context.Instructors.AnyAsync(i => i.InstructorID == instructor.InstructorID))
                {
                    ModelState.AddModelError("InstructorID", "An instructor with this Instructor ID already exists.");
                    return View(instructor);
                }

                _context.Instructors.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        // GET: Edit View from Database
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");
            var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.InstructorID == id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }

        // POST: Update Instructor in Database
        [HttpPost]
        public async Task<IActionResult> Edit(Instructor instructor)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Instructors.Update(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        // GET: Delete View from Database
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");
            var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.InstructorID == id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }

        // POST: Delete Instructor from Database
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");
            var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.InstructorID == id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}