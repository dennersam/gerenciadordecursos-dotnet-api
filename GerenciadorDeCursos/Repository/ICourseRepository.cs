using GerenciadorDeCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();

        Course GetCourseByStatus(Status id);
    }
}
