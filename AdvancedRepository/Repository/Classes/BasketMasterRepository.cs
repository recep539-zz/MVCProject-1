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
    public class BasketMasterRepository:BaseRepository<BasketMaster>,IBasketMasterRepository
    {
        public BasketMasterRepository(CompanyContext db):base(db)
        {

        }

    }
}
