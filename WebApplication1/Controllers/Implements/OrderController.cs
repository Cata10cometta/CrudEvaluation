using Business.Interfaces;
using Entity.Dto.OrderDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    public class OrderController : GenericController<OrderDto, Order>, IOrderController
    {
        private readonly IOrderBusiness _OrderBusiness;

        public OrderController(IOrderBusiness OrderBusiness, ILogger<OrderController> logger)
            : base(OrderBusiness, logger)
        {
            _OrderBusiness = OrderBusiness;
        }

        protected override int GetEntityId(OrderDto dto)
        {
            return dto.Id;
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePartialOrder(int id, [FromBody] UpdateOrderDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _OrderBusiness.UpdatePartialOrderAsync(dto);
                return Ok(new { success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Pedido: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Pedido: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicOrder(int id)
        {
            try
            {
                var dto = new DeleteLogiOrderDto { Id = id, Status = false }; // Se inicializa la propiedad requerida 'Status'
                var result = await _OrderBusiness.DeleteLogicOrderAsync(dto);
                if (!result)
                    return NotFound($"Pedido con ID {id} no encontrado");

                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Pedido: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Pedido: {ex.Message}");
                return StatusCode(500, "Error interno del servidror");
            }
        }
    }
}
