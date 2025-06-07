using Entity.Dto.TuitionDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface ITuitionController : IGenericController<TuitionDto, Tuition>
    {
        Task<IActionResult> UpdatePartialTuition(int id, int TuitionId, [FromBody] UpdateTuitionDto dto);
        Task<IActionResult> DeleteLogicTuition(int id);
    }
}
