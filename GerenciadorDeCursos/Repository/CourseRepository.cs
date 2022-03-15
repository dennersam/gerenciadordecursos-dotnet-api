using GerenciadorDeCursos.Data;
using GerenciadorDeCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;

        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Course.ToList();
        }

        public Course GetCourseByStatus(Status status)
        {
            var course = _context.Course.Find(status);

            if(course == null) return null;

            return course;
        }
    }
}
