using Entity.Dto.CourseDTO;
using Entity.Dto.CourserDTO;
using Entity.Model;

namespace Business.Interfaces
{
    public interface ICourseBusiness : IBaseBusiness<Course, CourseDto>    
    {
        Task<bool> UpdatePartialCourseAsync(UpdateCourseDto dto);
        Task<bool> DeleteLogicCourseAsync(DeleteLogiCourseDto dto);
    }
}
