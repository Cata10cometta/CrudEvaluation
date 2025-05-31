using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dto.CustomerDTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class CustomerBusiness : BaseBusiness<Customer, CustomerDto>, ICustomerBusiness
    {
        private readonly ICustomerData _customerData;

        public CustomerBusiness(
            ICustomerData customerData,
            IMapper mapper,
            ILogger<CustomerBusiness> logger)
            : base(customerData, mapper, logger)
        {
            _customerData = customerData;
        }

        /// <summary>
        /// Actualiza Parcialmente un cliente existente.
        /// </summary>
        /// <summary>
        /// Actualiza parcialmente una ciudad en la base de datos.
        /// </summary>
        public async Task<bool> UpdatePartialCustomerAsync(UpdateCustomerDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var customer = _mapper.Map<Customer>(dto);
            var result = await _customerData.UpdatePartial(customer);
            return result;
        }

        /// <summary>
        /// Desactiva un cliente en la base de datos.
        /// </summary>
        public async Task<bool> DeleteLogicCustomerAsync(DeleteLogiCustomerDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del cliente es inválido.");

            var exists = await _customerData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("ciudad", dto.Id);

            return await _customerData.ActiveAsync(dto.Id, dto.Status);

        }
    }
}
