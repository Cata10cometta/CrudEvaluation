using Entity.Dto.CustomerDTO;
using Entity.Model;

namespace Business.Interfaces
{
    public interface ICustomerBusiness : IBaseBusiness<Customer, CustomerDto>
    {
        Task<bool> UpdatePartialCustomerAsync(UpdateCustomerDto dto);
        Task<bool> DeleteLogicCustomerAsync(DeleteLogiCustomerDto dto);
    }
}
