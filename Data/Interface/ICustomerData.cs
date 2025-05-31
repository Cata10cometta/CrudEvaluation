using Entity.Model;

namespace Data.Interface
{
    public interface ICustomerData : IBaseModelData<Customer>
    {
        Task<bool> ActiveAsync(int id, bool active);
        Task<bool> UpdatePartial(Customer customer);
    }
}
