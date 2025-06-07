using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Tuition : BaseModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime Fecha { get; set; }
        public string Description { get; set; }

        public student Student { get; set; }
        public Course Course { get; set; }
    }
}
