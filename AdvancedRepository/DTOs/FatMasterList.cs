using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class FatMasterList
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public bool Deleted { get; set; }     
    }
}
