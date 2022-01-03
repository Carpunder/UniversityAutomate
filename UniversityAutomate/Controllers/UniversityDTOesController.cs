#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityAutomate;
using UniversityAutomate.Areas.Admin.Models;
using UniversityAutomate.Models;

namespace UniversityAutomate.Controllers
{
    public class UniversityDTOesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UniversityDTOesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("University/")]
        public async Task<IActionResult> Index()
        {
            var universities = await _context.Universities
                .Include(g => g.Groups)
                .Include(c => c.City).ToListAsync();
            if (!universities.Any())
            {
                return NotFound();
            }
            var universitiesDTO = _mapper.Map<IEnumerable<University>, IEnumerable<UniversityDTO>>(universities);
            return View(universitiesDTO);
        }

        // GET: UniversityDTOes
        [Route("City/{cityName}/University/")]
        public async Task<IActionResult> Index(string cityName)
        {
            var universities = await _context.Universities
                .Include(g => g.Groups)
                .Include(c => c.City)
                .Where(c => c.City.CityName == cityName).ToListAsync();
            if (!universities.Any())
            {
                return NotFound();
            }
            var universitiesDTO = _mapper.Map<IEnumerable<University>, IEnumerable<UniversityDTO>>(universities);
            return View(universitiesDTO);
        }

        // GET: UniversityDTOes/Details/5
        [Route("University/{universityName}/")]
        public async Task<IActionResult> Details(string universityName)
        {
            if (universityName == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .Include(g => g.Groups)
                .Include(u => u.City)
                .FirstOrDefaultAsync(m => m.UniversityName == universityName);
            if (university == null)
            {
                return NotFound();
            }

            var universityDTO = _mapper.Map<UniversityDTO>(university);

            return View(universityDTO);
        }

    }
}
