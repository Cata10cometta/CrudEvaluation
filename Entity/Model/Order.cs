using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Order : BaseModel
    {
        public string Product { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
