using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.ViewModels
{
    public class FatMasterModel
    {
        public FatMasterModel()
        {
            FatMasters = new FatMaster();
        }
        public FatMaster FatMasters { get; set; }
        public string Title { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public IQueryable<CustomerSelect> CustomerList { get; set; }
        public FatDetail FatDetail { get; set; }//Sonradan eklendi
    }
}
