using AutoMapper;
using Entity.Dto.TuitionDTO;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class TuitionProfile : Profile
    {
        public TuitionProfile()
        {
            CreateMap<Tuition, TuitionDto>().ReverseMap();
        }
    }
}
