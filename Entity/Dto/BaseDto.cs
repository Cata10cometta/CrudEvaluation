using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
       
    }
}
