using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlingorWebShop.Shared
{
    public class CartDto
    {
        public int UserId { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
