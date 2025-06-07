using AutoMapper;
using Entity.Dto.StudentDTO;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<student, StudentDto>().ReverseMap();
        }
    }
}
