using AutoMapper;
using GerenciadorDeCursos.DTOs;
using GerenciadorDeCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CreateCourseDTO>();
            CreateMap<CreateCourseDTO, Course>();
        }
    }
}
