using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class Users
    {
        public Users()
        {
            BasketMaster = new HashSet<BasketMaster>();
        }
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<BasketMaster> BasketMaster { get; set; }
    }
}
