using Business.Interfaces;
using Entity.Dto.TuitionDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class TuitionController : GenericController<TuitionDto, Tuition>, ITuitionController
    {
        private readonly ITuitionBusiness _TuitionBusiness;
        public TuitionController(ITuitionBusiness TuitionBusiness, ILogger<TuitionController> logger)
            : base(TuitionBusiness, logger)
        {
            _TuitionBusiness = TuitionBusiness;
        }
        protected override int GetEntityId(TuitionDto dto)
        {
            return dto.Id;
        }
        [HttpPatch]
        public async Task<IActionResult> UpdatePartialTuition(int id, int TuitionId, [FromBody] UpdateTuitionDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = await _TuitionBusiness.UpdatePartialTuitionAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Tuition: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Tuition: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicTuition(int id)
        {
            try
            {
                var dto = new DeleteLogiTuitionDto { Id = id, Status = false }; // Se inicializa la propiedad requerida 'Status'
                var result = await _TuitionBusiness.DeleteLogicTuitionAsync(dto);
                if (!result)
                    return NotFound($"Tuition con ID {id} no encontrada");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Tuition: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Tuition: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
