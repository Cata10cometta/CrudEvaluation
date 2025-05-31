using AutoMapper;
using Entity.Dto.OrderDTO;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
