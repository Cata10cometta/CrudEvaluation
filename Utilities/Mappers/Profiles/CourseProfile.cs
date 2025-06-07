using AutoMapper;
using Entity.Dto.CourseDTO;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
