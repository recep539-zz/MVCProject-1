using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class Supplier: EnterPrize
    {
        public Supplier()
        {
            Products = new HashSet<Product>();

        }

        public bool Producer { get; set; }

        [ForeignKey("CountyId")]
        public County County { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
