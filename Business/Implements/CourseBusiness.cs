using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dto.CourserDTO;
using Entity.Dto.CourseDTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class CourseBusiness : BaseBusiness<Course, CourseDto>, ICourseBusiness
    {
        private readonly ICourseData _CourseData;
        

        public CourseBusiness(
            ICourseData courseData,
            IMapper mapper,
            ILogger<CourseBusiness> logger)
            : base(courseData, mapper, logger)
        {
            _CourseData = courseData;
        }

        /// <summary>
        /// Actualiza Parcialmente un curso existente.
        /// </summary>
        public async Task<bool> UpdatePartialCourseAsync(UpdateCourseDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var course = _mapper.Map<Course>(dto);
            var result = await _CourseData.UpdatePartial(course);
            return result;
        }

        /// <summary>
        /// Desactiva un curso en la base de datos.
        /// </summary>
        public async Task<bool> DeleteLogicCourseAsync(DeleteLogiCourseDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del curso es inválido.");

            var exists = await _CourseData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("curse", dto.Id);

            return await _CourseData.ActiveAsync(dto.Id, dto.Status);
            


        }
    }
}
