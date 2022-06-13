using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{

    public class County: Base
    {
        public County()
        {
            Employees = new HashSet<Employee>();
            Customers = new HashSet<Customer>();
            Suppliers = new HashSet<Supplier>();
        }
        public string CountyName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
