using Business.Interfaces;
using Entity.Dto.CourseDTO;
using Entity.Dto.CourserDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class CourseController : GenericController<CourseDto, Course>, ICourseController
    {
        private readonly ICourseBusiness _CourseBusiness;

        public CourseController(ICourseBusiness CourseBusiness, ILogger<CourseController> logger)
            : base(CourseBusiness, logger)
        {
            _CourseBusiness = CourseBusiness;
        }

        protected override int GetEntityId(CourseDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialCourse( [FromBody] UpdateCourseDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _CourseBusiness.UpdatePartialCourseAsync(dto);
                return Ok(new { success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Course: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Course: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicCourse(int id)
        {
            try
            {
                var dto = new DeleteLogiCourseDto { Id = id, Status = false }; // Se inicializa la propiedad requerida 'Status'
                var result = await _CourseBusiness.DeleteLogicCourseAsync(dto);
                if (!result)
                    return NotFound($"Course con ID {id} no encontrado");

                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Course: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Course: {ex.Message}");
                return StatusCode(500, "Error interno del servidror");
            }
        }
    }
}
