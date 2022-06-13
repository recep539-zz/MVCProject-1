using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.ViewModels
{
    public class ProductModel
    {
 
        public Product Product { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public string Title { get; set; }
        public IQueryable<CategoryList> CategoryList { get; set; }
        public IQueryable<SupplierList> SupplierList { get; set; }
        public IQueryable<UnitList> UnitList { get; set; }
        public IQueryable<EmployeeList> EmployeeList { get; set; }
    }
}
