using System;

namespace AdvancedRepository.DTOs
{
    public class EmployeeList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public char Gender { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public string ManagerName { get; set; } //inner join ile yapılacak
        public bool IsManager { get; set; }
        public string FullAddress { get; set; }
        public int PhoneNumber { get; set; }
        public bool Deleted { get; set; }
    }
}
