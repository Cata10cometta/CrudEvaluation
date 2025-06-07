using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.StudentDTO
{
    public class StudentDto : BaseDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
