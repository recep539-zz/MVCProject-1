using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Interfaces
{
    public  interface IFatDetailRepository:IBaseRepository<FatDetail>
    {
        IQueryable<FatDetailList> GetFatDetailList(int id);
        string FatTotal(IQueryable<FatDetailList> fd);
    }
}
