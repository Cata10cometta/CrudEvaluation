using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.TuitionDTO
{
    public class TuitionDto : BaseDto
    {
        public string Description { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
