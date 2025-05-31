using AutoMapper;
using Entity.Dto.CustomerDTO;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
