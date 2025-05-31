using Business.Interfaces;
using Entity.Dto.CustomerDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class CustomerController : GenericController<CustomerDto, Customer>, ICustomerController
    {
        private readonly ICustomerBusiness _CustomerBusiness;
        public CustomerController(ICustomerBusiness CustomerBusiness, ILogger<CustomerController> logger)
            : base(CustomerBusiness, logger)
        {
            _CustomerBusiness = CustomerBusiness;
        }
        protected override int GetEntityId(CustomerDto dto)
        {
            return dto.Id;
        }
        [HttpPatch]
        public async Task<IActionResult> UpdatePartialCustomer(int id, int CustomerId, [FromBody] UpdateCustomerDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = await _CustomerBusiness.UpdatePartialCustomerAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Cliente: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Cliente: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicCustomer(int id)
        {
            try
            {
                var dto = new DeleteLogiCustomerDto { Id = id, Status = false }; // Se inicializa la propiedad requerida 'Status'
                var result = await _CustomerBusiness.DeleteLogicCustomerAsync(dto);
                if (!result)
                    return NotFound($"Cliente con ID {id} no encontrada");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Cliente: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Cliente: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
