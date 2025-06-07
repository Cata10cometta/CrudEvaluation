using AutoMapper;
using Entity.Dto.CourseDTO;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UpdateCourseDto, Course>();
            CreateMap<Course, CourseDto>(); // si necesitas el inverso
                                            // otros mapeos...
        }
    }
}
