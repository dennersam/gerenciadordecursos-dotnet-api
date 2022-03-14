using AutoMapper;
using GerenciadorDeCursos.Data;
using GerenciadorDeCursos.DTOs;
using GerenciadorDeCursos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CourseContext _context;

        public CourseController(IMapper mapper, CourseContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Course.ToListAsync();
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CreateCourseDTO course)
        {
            var NewCourse = _mapper.Map<Course>(course);

            return Ok(NewCourse);
        }
    }
}
