using Data.Implements.BaseData;
using Data.Interface;
using Entity.Context;
using Entity.Model;

namespace Data.Implements
{
    public class CustomerData : BaseModelData<Customer>, ICustomerData
    {
        public CustomerData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var customer = await _context.Set<Customer>().FindAsync(id);
            if (customer == null)
                return false;
            // Actualizar el estado del cliente
            customer.Status = active;
            _context.Entry(customer).Property(u => u.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePartial(Customer customer)
        {
            var existingcustomer = await _context.customers.FindAsync(customer.Id);
            if (existingcustomer == null)
                return false;

            // Solo se actualizan campos permitidos
            existingcustomer.Name = customer.Name;

            // Marcar explícitamente los campos modificados
            _context.Entry(existingcustomer).Property(r => r.Name).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
