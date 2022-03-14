using GerenciadorDeCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.DTOs
{
    public class CreateCourseDTO
    {
        public string Title { get; set; }
        public string time { get; set; }
        public Status status { get; set; }
    }
}
