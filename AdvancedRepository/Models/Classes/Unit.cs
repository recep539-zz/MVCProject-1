using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class Unit: Base
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }
        public string UnitName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
