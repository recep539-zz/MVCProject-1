using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class FatMaster:Base
    {
        public FatMaster()
        {
            FatDetail = new HashSet<FatDetail>();
        }
        public DateTime Date  { get; set; }
        public int CustomerId { get; set; }      
        public ICollection<FatDetail> FatDetail { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }     
    }
}
