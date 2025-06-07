using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public int Credits { get; set; }

        public List<Tuition> Tuitions { get; set; } // Assuming Estudiante is the student model
    }
}
