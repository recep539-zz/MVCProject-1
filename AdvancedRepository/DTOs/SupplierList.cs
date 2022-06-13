using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class SupplierList
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string FullAddress { get; set; }
        public int PhoneNumber { get; set; }
        public bool Deleted { get; set; }
    }
}
