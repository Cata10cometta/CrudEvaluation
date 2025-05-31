using Entity.Dto.OrderDTO;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IOrderBusiness : IBaseBusiness<Order, OrderDto>    
    {
        Task<bool> UpdatePartialOrderAsync(UpdateOrderDto dto);
        Task<bool> DeleteLogicOrderAsync(DeleteLogiOrderDto dto);
    }
}
