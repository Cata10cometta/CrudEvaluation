using Entity.Dto.StudentDTO;
using Entity.Dto.StudentDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface IStudentController : IGenericController<StudentDto, student>
    {
        Task<IActionResult> UpdatePartialStudent(int id, int StudentId, [FromBody] UpdateStudentDto dto);
        Task<IActionResult> DeleteLogicStudent(int id);
    }
}
