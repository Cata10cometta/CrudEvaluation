using Entity.Dto.TuitionDTO;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ITuitionBusiness : IBaseBusiness<Tuition, TuitionDto>
    {
        Task<bool> UpdatePartialTuitionAsync(UpdateTuitionDto dto);
        Task<bool> DeleteLogicTuitionAsync(DeleteLogiTuitionDto dto);
    }
}
