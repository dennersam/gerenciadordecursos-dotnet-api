using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Models
{
    public class Course
    {
        public int id { get; set; }

        [Required(ErrorMessage = "The title is required!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The course´s time is required!!!")]
        public string time { get; set; }

        
    }
}
