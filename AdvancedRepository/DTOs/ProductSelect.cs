using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class ProductSelect
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public bool Deleted { get; set; }


    }
}
