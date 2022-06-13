using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.ViewModels
{
    public class FatDetailModel
    {
        public FatDetailModel()
        {
            FatDetail = new FatDetail();
        }
        public IQueryable<ProductSelect> ProductSelect { get; set; }      
        public FatMaster FatMaster { get; set; }
        public FatDetail FatDetail { get; set; }
        public IQueryable<FatDetailList> FatDetailLists { get; set; }
        public IQueryable<CustomerSelect> Customers { get; set; }
        public string Total { get; set; }
        //public Product Product { get; set; }// modele ekleyerek dene

    }
}
