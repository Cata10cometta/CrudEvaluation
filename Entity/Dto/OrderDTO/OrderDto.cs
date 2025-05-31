using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.OrderDTO
{
    public class OrderDto : BaseDto
    {
        public string Product { get; set; }
        public int CustomerId { get; set; }
    }
}
