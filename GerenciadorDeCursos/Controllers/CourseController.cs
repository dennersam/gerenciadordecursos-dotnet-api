using GerenciadorDeCursos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            return Ok();
        }
    }
}
