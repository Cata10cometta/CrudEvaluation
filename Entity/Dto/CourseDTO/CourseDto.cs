using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.CourseDTO
{
    public class CourseDto : BaseDto
    {
        public string Name { get; set; }
        public int Credits { get; set; }
    }
}
