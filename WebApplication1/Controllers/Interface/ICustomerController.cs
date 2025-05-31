using Entity.Dto.CustomerDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface ICustomerController : IGenericController<CustomerDto, Customer>
    {
        Task<IActionResult> UpdatePartialCustomer(int id, int CustomerId, [FromBody] UpdateCustomerDto dto);
        Task<IActionResult> DeleteLogicCustomer(int id);
    }
}
