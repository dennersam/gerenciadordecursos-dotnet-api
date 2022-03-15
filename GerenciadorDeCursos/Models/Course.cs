
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciadorDeCursos.Models
{
    public class Course
    {
        public int id { get; set; }

        public string Title { get; set; }

        public string time { get; set; }

        public virtual Status status { get; set; }

    }
}
