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
    public class UniversitiesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UniversitiesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Universities
        public async Task<IActionResult> Index()
        {
            var universities = _context.Universities.Include(u => u.City);
            return View(_mapper.Map<IEnumerable<University>, IEnumerable<UniversityAdminDTO>>(universities));
        }

        // GET: Universities/Details/5
        public async Task<IActionResult> Details(int? universityId)
        {
            if (universityId == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .Include(u => u.City)
                .FirstOrDefaultAsync(m => m.UniversityID == universityId);
            if (university == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UniversityAdminDTO>(university));
        }

        // GET: Universities/Create
        public IActionResult Create()
        {
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName");
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversityName,Address,CityID")] University university)
        {
            if (ModelState.IsValid)
            {
                _context.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", university.CityID);
            return View(university);
        }

        // GET: Universities/Edit/5
        public async Task<IActionResult> Edit(int? universityId)
        {
            if (universityId == null)
            {
                return NotFound();
            }

            var university = await _context.Universities.FindAsync(universityId);
            if (university == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", university.CityID);
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int universityId, [Bind("UniversityID,UniversityName,Address,CityID")] University university)
        {
            if (universityId != university.UniversityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(university);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(university.UniversityID))
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
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", university.CityID);
            return View(university);
        }

        // GET: Universities/Delete/5
        public async Task<IActionResult> Delete(int? universityId)
        {
            if (universityId == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .Include(u => u.City)
                .FirstOrDefaultAsync(m => m.UniversityID == universityId);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int universityId)
        {
            var university = await _context.Universities.FindAsync(universityId);
            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityExists(int universityId)
        {
            return _context.Universities.Any(e => e.UniversityID == universityId);
        }
    }
}
