using Entity.Dto.CourseDTO;
using Entity.Dto.StudentDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface ICourseController : IGenericController<CourseDto, Course>
    {
        Task<IActionResult> UpdatePartialCourse([FromBody] UpdateCourseDto dto);
        Task<IActionResult> DeleteLogicCourse(int id);
    }
  
}
