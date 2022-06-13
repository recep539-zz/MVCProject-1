using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class BasketMaster:Base
    {
        public DateTime Date  { get; set; } 
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }

    }
}
