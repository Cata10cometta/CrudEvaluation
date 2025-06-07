using Data.Interface;
using Entity.Context;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class CourseData : BaseModelData<Course>, ICourseData
    {
        public CourseData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var Course = await _context.Set<Course>().FindAsync(id);
            if (Course == null)
                return false;
            // Actualizar el estado del pedido
            Course.Status = active;
            Course.DeleteAt = active ? null : DateTime.UtcNow.AddHours(-5);
            _context.Entry(Course).Property(u => u.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePartial(Course Course)
        {
            var existingCourse = await _context.Courses.FindAsync(Course.Id);
            if (existingCourse == null)
                return false;
            // Solo se actualizan campos permitidos
            existingCourse.Name = Course.Name;
            // Marcar explícitamente los campos modificados
            _context.Entry(existingCourse).Property(r => r.Name).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
