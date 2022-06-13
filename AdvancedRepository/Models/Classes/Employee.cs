using AdvancedRepository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class Employee: Base, IAddress
    {
        public Employee()
        {
            Products = new HashSet<Product>();
        }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public char Gender { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public bool IsManager { get; set; }
        public string Street { get; set; }
        public string Avenue { get; set; }
        public int CountyId { get; set; }
        public int OutDoorNumber { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateofBirth { get; set; }

        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }
        public List<Employee> Managers { get; set; } //public ICollection<Employee> Managers
         
        [ForeignKey("CountyId")]
        public County County { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
