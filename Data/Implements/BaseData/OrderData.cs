using Data.Interface;
using Entity.Context;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class OrderData : BaseModelData<Order>, IOrderData
    {
        public OrderData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var order = await _context.Set<Order>().FindAsync(id);
            if (order == null)
                return false;
            // Actualizar el estado del pedido
            order.Status = active;
            _context.Entry(order).Property(u => u.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePartial(Order order)
        {
            var existingOrder = await _context.orders.FindAsync(order.Id);
            if (existingOrder == null)
                return false;
            // Solo se actualizan campos permitidos
            existingOrder.Product = order.Product;
            // Marcar explícitamente los campos modificados
            _context.Entry(existingOrder).Property(r => r.Product).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
