using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRepository.Repository.Interfaces
{
    public interface ICountyRepository: IBaseRepository<County>
    {
        IQueryable<CountyList> GetCountyList();
        IQueryable<CountyList> RecoverCountyList();
        IQueryable<CountyList> ListByCityId(int id);
    }
}
