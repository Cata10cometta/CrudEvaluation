using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class student : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Tuition> Tuitions { get; set; }
    }
}
