using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dto.TuitionDTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class TuitionBusiness : BaseBusiness<Tuition, TuitionDto>, ITuitionBusiness
    {
        private readonly ITuitionData _TuitionData;

        public TuitionBusiness(
            ITuitionData TuitionData,
            IMapper mapper,
            ILogger<TuitionBusiness> logger)
            : base(TuitionData, mapper, logger)
        {
            _TuitionData = TuitionData;
        }

        /// <summary>
        /// Actualiza Parcialmente un Tuition existente.
        /// </summary>
        /// <summary>
        /// Actualiza parcialmente una Tuition en la base de datos.
        /// </summary>
        public async Task<bool> UpdatePartialTuitionAsync(UpdateTuitionDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var Tuition = _mapper.Map<Tuition>(dto);
            var result = await _TuitionData.UpdatePartial(Tuition);
            return result;
        }

        /// <summary>
        /// Desactiva un Tuition en la base de datos.
        /// </summary>
        public async Task<bool> DeleteLogicTuitionAsync(DeleteLogiTuitionDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del Tuition es inválido.");

            var exists = await _TuitionData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("Tuition", dto.Id);

            return await _TuitionData.ActiveAsync(dto.Id, dto.Status);

        }
    }
}
