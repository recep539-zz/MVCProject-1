using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class Customer: EnterPrize
    {
        public Customer()
        {
            FatMaster=new HashSet<FatMaster>();
        }
        public int Rating { get; set; }

        [ForeignKey("CountyId")]
        public County County { get; set; }
        public ICollection<FatMaster> FatMaster { get; set; }
    }
}
