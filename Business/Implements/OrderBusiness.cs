using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dto.OrderDTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class OrderBusiness : BaseBusiness<Order, OrderDto>, IOrderBusiness
    {
        private readonly IOrderData _orderData;

        public OrderBusiness(
            IOrderData orderData,
            IMapper mapper,
            ILogger<OrderBusiness> logger)
            : base(orderData, mapper, logger)
        {
            _orderData = orderData;
        }

        /// <summary>
        /// Actualiza Parcialmente una orden existente.
        /// </summary>
        public async Task<bool> UpdatePartialOrderAsync(UpdateOrderDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var order = _mapper.Map<Order>(dto);
            var result = await _orderData.UpdatePartial(order);
            return result;
        }

        /// <summary>
        /// Desactiva un cliente en la base de datos.
        /// </summary>
        public async Task<bool> DeleteLogicOrderAsync(DeleteLogiOrderDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del pedido es inválido.");

            var exists = await _orderData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("ciudad", dto.Id);

            return await _orderData.ActiveAsync(dto.Id, dto.Status);

        }
    }
}
