using Data.Interface;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.BaseData
{
    public class TuitionData : BaseModelData<Tuition>, ITuitionData
    {
        public TuitionData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var Tuition = await _context.Set<Tuition>().FindAsync(id);
            if (Tuition == null)
                return false;
            // Actualizar el estado del cliente
            Tuition.Status = active;
            Tuition.DeleteAt = active ? null : DateTime.UtcNow.AddHours(-5);

            _context.Entry(Tuition).Property(u => u.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePartial(Tuition Tuition)
        {
            var existingTuition = await _context.Tuitions.FindAsync(Tuition.Id);
            if (existingTuition == null)
                return false;

            // Solo se actualizan campos permitidos
            existingTuition.StudentId = Tuition.StudentId;

            // Marcar explícitamente los campos modificados
            _context.Entry(existingTuition).Property(r => r.StudentId).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
