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
    public class GroupDTOesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GroupDTOesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: GroupDTOes
        [Route("Group/")]
        public async Task<IActionResult> Index()
        {
            var groups = await _context.Groups
                .Include(u => u.University)
                .Include(s => s.Students).ToListAsync();
            var groupsDTO = _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(groups);
            
            return View(groupsDTO);
        }
        
        [Route("University/{universityName}/Group/")]
        public async Task<IActionResult> Index(string universityName)
        {
            var groups = await _context.Groups
                .Include(u => u.University)
                .Include(s => s.Students)
                .Where(g => g.University.UniversityName == universityName).ToListAsync();
            var groupsDTO = _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(groups);
            
            return View(groupsDTO);
        }

        // GET: GroupDTOes/Details/5
        [Route("University/{universityName}/Group/{groupName}")]
        public async Task<IActionResult> Details(string universityName, string groupName)
        {
            if (groupName == null || universityName == null)
            {
                return NotFound();
            }

            var group = await _context.Groups
                .Include(s => s.Students)
                .Include(u => u.University)
                .FirstOrDefaultAsync(g => g.GroupName == groupName && g.University.UniversityName == universityName);
            if (group == null)
            {
                return NotFound();
            }
            
            var groupDTO = _mapper.Map<GroupDTO>(group);
            
            return View(groupDTO);
        }

    }
}
