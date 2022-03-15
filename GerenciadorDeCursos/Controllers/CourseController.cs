using AutoMapper;
using GerenciadorDeCursos.Data;
using GerenciadorDeCursos.DTOs;
using GerenciadorDeCursos.Models;
using GerenciadorDeCursos.Repository;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ICourseRepository _courseRepository;

        public CourseController(IMapper mapper, CourseContext context, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _context = context;
            _courseRepository = courseRepository;
        }

        
        [HttpGet]
        public IActionResult GetCourses()
        {
            var coursesReturn = _courseRepository.GetAllCourses();
            return Ok(coursesReturn);
        }

        
        [HttpGet("{status}")]
        public IActionResult GetCoursesByStatus(Status status)
        {
            var course = _courseRepository.GetCourseByStatus(status);
            
            if (course == null) return NotFound();
            
            return Ok(course);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public IActionResult CreateCourse([FromBody] CreateCourseDTO course)
        {
            var NewCourse = _mapper.Map<Course>(course);
            _context.Course.Add(NewCourse);
            _context.SaveChanges();

            return Ok(NewCourse);
        }

        [Authorize(Roles = "Manager")]
        [Authorize(Roles = "Secretary")]
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CreateCourseDTO Newcourse)
        {
            Course course = _context.Course.FirstOrDefault(course => course.id == id);
            if (course == null) return NotFound();
            course.Title = Newcourse.Title;
            course.time = Newcourse.time;
            course.status = Newcourse.status;

            _context.SaveChanges();
            return NoContent();
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            Course course = _context.Course.FirstOrDefault(course => course.id == id);
            if (course == null) return NotFound();
            _context.Remove(course);
            _context.SaveChanges();
            return NoContent();


        }
    }
}
