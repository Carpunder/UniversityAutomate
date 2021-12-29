#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityAutomate.Areas.Admin.Models;

namespace UniversityAutomate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class GroupsController : Controller
    {
        private readonly AppDbContext _context;

        public GroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Groups.Include(x => x.University);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? groupId)
        {
            if (groupId == null)
            {
                return NotFound();
            }

            var group = await _context.Groups
                .Include(x => x.University)
                .FirstOrDefaultAsync(m => m.GroupID == groupId);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["UniversityID"] = new SelectList(_context.Universities, "UniversityID", "UniversityID");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupName,UniversityID")] Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityID"] = new SelectList(_context.Universities, "UniversityID", "UniversityID", group.UniversityID);
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? groupId)
        {
            if (groupId == null)
            {
                return NotFound();
            }

            var group = await _context.Groups.FindAsync(groupId);
            if (group == null)
            {
                return NotFound();
            }
            ViewData["UniversityID"] = new SelectList(_context.Universities, "UniversityID", "UniversityID", group.UniversityID);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int groupId, [Bind("GroupID,GroupName,UniversityID")] Group group)
        {
            if (groupId != group.GroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Groups.Update(group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.GroupID))
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
            ViewData["UniversityID"] = new SelectList(_context.Universities, "UniversityID", "UniversityID", group.UniversityID);
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? groupId)
        {
            if (groupId == null)
            {
                return NotFound();
            }

            var group = await _context.Groups
                .Include(x => x.University)
                .FirstOrDefaultAsync(m => m.GroupID == groupId);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int groupId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int groupId)
        {
            return _context.Groups.Any(e => e.GroupID == groupId);
        }
    }
}
