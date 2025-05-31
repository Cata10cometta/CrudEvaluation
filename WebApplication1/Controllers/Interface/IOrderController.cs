using Entity.Dto.OrderDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface IOrderController : IGenericController<OrderDto, Order>
    {
        Task<IActionResult> UpdatePartialOrder(int id, Entity.Dto.OrderDTO.UpdateOrderDto dto);
        Task<IActionResult> DeleteLogicOrder(int id);
    }
  
}
