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
    public class StudentDTOesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentDTOesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: StudentDTOes
        [Route("Student/")]
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(g => g.Group)
                .Include(c=> c.City)
                .Include(u => u.Group.University).ToListAsync();
            var citiesDTO = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
            
            return View(citiesDTO);
        }
        
        [Route("City/{cityName}/Student")]
        public async Task<IActionResult> Index(string cityName)
        {
            var students = await _context.Students
                .Include(g => g.Group)
                .Include(c=> c.City)
                .Include(u => u.Group.University)
                .Where(s => s.City.CityName == cityName).ToListAsync();
            var citiesDTO = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
            
            return View(citiesDTO);
        }
        
        [Route("University/{universityName}/Group/{groupName}/Student")]
        public async Task<IActionResult> Index(string universityName, string groupName)
        {
            var students = await _context.Students
                .Include(c => c.City)
                .Include(g => g.Group)
                .Include(u => u.Group.University)
                .Where(s => s.Group.GroupName == groupName && s.Group.University.UniversityName == universityName)
                .ToListAsync();
            var studentsDTO = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
            
            return View(studentsDTO);
        }

        // GET: StudentDTOes/Details/5
        [Route("/Student/{studentName}")]
        public async Task<IActionResult> Details(string studentName)
        {
            if (studentName == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.City)
                .Include(s => s.Group)
                .Include(u => u.Group.University)
                .FirstOrDefaultAsync(m => m.StudentName == studentName);
            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = _mapper.Map<StudentDTO>(student);
            
            return View(studentDTO);
        }
        
        // GET: StudentDTOes/Details/5
        [Route("University/{universityName}/Group/{groupName}/Student/{studentName}")]
        public async Task<IActionResult> Details(string universityName, string groupName, string studentName)
        {
            if (studentName == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.City)
                .Include(s => s.Group)
                .Include(u => u.Group.University)
                .Where(s => s.Group.GroupName == groupName && s.Group.University.UniversityName == universityName)
                .FirstOrDefaultAsync(m => m.StudentName == studentName);
            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = _mapper.Map<StudentDTO>(student);
            
            return View(studentDTO);
        }
        
    }
}
