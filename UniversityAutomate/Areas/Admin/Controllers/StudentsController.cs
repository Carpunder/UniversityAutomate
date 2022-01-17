#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityAutomate.Areas.Admin.Models;
using UniversityAutomate.Areas.Admin.ViewModels;

namespace UniversityAutomate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = _context.Students
                .Include(g => g.Group)
                .Include(c => c.City)
                .Include(u => u.Group.University);
            return View(_mapper.Map<IEnumerable<Student>, IEnumerable<StudentAdminDTO>>(students));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(g => g.Group)
                .Include(c=> c.City)
                .Include(u => u.Group.University)
                .FirstOrDefaultAsync(m => m.StudentID == studentId);
            if (student == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StudentAdminDTO>(student));
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName");
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentName,Birthday,Bursary,Bonus,CityID,GroupID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", student.CityID);
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", student.GroupID);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", student.CityID);
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", student.GroupID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int studentId, [Bind("StudentID,StudentName,Birthday,Bursary,Bonus,CityID,GroupID")] Student student)
        {
            if (studentId != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Students.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
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
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", student.CityID);
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", student.GroupID);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.City)
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.StudentID == studentId);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int studentId)
        {
            return _context.Students.Any(e => e.StudentID == studentId);
        }
    }
}
