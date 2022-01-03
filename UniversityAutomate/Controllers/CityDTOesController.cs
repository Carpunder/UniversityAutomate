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
    public class CityDTOesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CityDTOesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: CityDTOes
        [Route("City/")]
        public async Task<IActionResult> Index()
        {
            var cities = await _context.Cities
                .Include(u => u.Universities)
                .Include(s => s.Students).ToListAsync();
            var citiesDTO = _mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(cities);
            
            return View(citiesDTO);
        }

        // GET: CityDTOes/Details/5
        [Route("City/{cityName}")]
        public async Task<IActionResult> Details(string cityName)
        {
            if (cityName == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .Include(u => u.Universities)
                .Include(s => s.Students)
                .FirstOrDefaultAsync(m => m.CityName == cityName);
            if (city == null)
            {
                return NotFound();
            }

            var cityDTO = _mapper.Map<CityDTO>(city);

            return View(cityDTO);
        }
    }
}
