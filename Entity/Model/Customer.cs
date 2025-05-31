using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Customer : BaseModel
    {
        public string Name { get; set; }

        public List<Order> orders { get; set; }
    }
}
