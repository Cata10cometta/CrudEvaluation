using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dto.StudentDTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class StudentBusiness : BaseBusiness<student, StudentDto>, IStudentBusiness
    {
        private readonly IStudentData _StudentData;

        public StudentBusiness(
            IStudentData StudentData,
            IMapper mapper,
            ILogger<StudentBusiness> logger)
            : base(StudentData, mapper, logger)
        {
            _StudentData = StudentData;
        }

        /// <summary>
        /// Actualiza Parcialmente un Student existente.
        /// </summary>
        /// <summary>
        /// Actualiza parcialmente una student en la base de datos.
        /// </summary>
        public async Task<bool> UpdatePartialStudentAsync(UpdateStudentDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var Student = _mapper.Map<student>(dto);
            var result = await _StudentData.UpdatePartial(Student);
            return result;
        }

        /// <summary>
        /// Desactiva un Student en la base de datos.
        /// </summary>
        public async Task<bool> DeleteLogicStudentAsync(DeleteLogiStudentDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del Student es inválido.");

            var exists = await _StudentData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("student", dto.Id);

            return await _StudentData.ActiveAsync(dto.Id, dto.Status);

        }
    }
}
