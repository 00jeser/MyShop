using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public string? Addres { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
