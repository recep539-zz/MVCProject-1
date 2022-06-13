using AdvancedRepository.Core;
using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class BasketDetailRepository: BaseRepository<BasketDetail>, IBasketDetailRepository
    {
        public BasketDetailRepository(CompanyContext db) : base(db)
        {
                
        }

    }
}
