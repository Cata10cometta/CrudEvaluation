using Business.Interfaces;
using Entity.Dto.StudentDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class StudentController : GenericController<StudentDto, student>, IStudentController
    {
        private readonly IStudentBusiness _StudentBusiness;
        public StudentController(IStudentBusiness StudentBusiness, ILogger<StudentController> logger)
            : base(StudentBusiness, logger)
        {
            _StudentBusiness = StudentBusiness;
        }
        protected override int GetEntityId(StudentDto dto)
        {
            return dto.Id;
        }
        [HttpPatch]
        public async Task<IActionResult> UpdatePartialStudent(int id, int StudentId, [FromBody] UpdateStudentDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = await _StudentBusiness.UpdatePartialStudentAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente student: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente student: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicStudent(int id)
        {
            try
            {
                var dto = new DeleteLogiStudentDto { Id = id, Status = false }; // Se inicializa la propiedad requerida 'Status'
                var result = await _StudentBusiness.DeleteLogicStudentAsync(dto);
                if (!result)
                    return NotFound($"Student con ID {id} no encontrada");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Student: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Student: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
