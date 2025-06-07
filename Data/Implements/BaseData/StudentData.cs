using Data.Interface;
using Entity.Context;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class StudentData : BaseModelData<student>, IStudentData
    {
        public StudentData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var Student = await _context.Set<student>().FindAsync(id);
            if (Student == null)
                return false;
            // Actualizar el estado del cliente
            Student.Status = active;
            Student.DeleteAt = active ? null : DateTime.UtcNow.AddHours(-5);

            _context.Entry(Student).Property(u => u.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePartial(student Student)
        {
            var existingStudent = await _context.Students.FindAsync(Student.Id);
            if (existingStudent == null)
                return false;

            // Solo se actualizan campos permitidos
            existingStudent.Name = Student.Name;

            // Marcar explícitamente los campos modificados
            _context.Entry(existingStudent).Property(r => r.Name).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
