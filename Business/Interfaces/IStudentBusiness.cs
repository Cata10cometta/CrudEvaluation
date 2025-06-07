using Entity.Dto.StudentDTO;
using Entity.Dto.StudentDTO;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IStudentBusiness : IBaseBusiness<student, StudentDto>
    {
        Task<bool> UpdatePartialStudentAsync(UpdateStudentDto dto);
        Task<bool> DeleteLogicStudentAsync(DeleteLogiStudentDto dto);
    }
}
