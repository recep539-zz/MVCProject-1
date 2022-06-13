using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRepository.Models.ViewModels
{
    public class SupplierModel
    {
        public Supplier Supplier { get; set; }
        public string Title { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public IQueryable<CountyList> CountyList { get; set; }// Listesini görmek istediğimiz class lar için yapıyoruz.
    }
}
