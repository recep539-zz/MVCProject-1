using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.ViewModels
{
    public class BasketModel
    {
        public IQueryable<ProductSelect> ProductsSelect { get; set; }
        public IQueryable<BasketList> basketLists { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public int Id { get; set; }


    }
}
