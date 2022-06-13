using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class UnitRepository: BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(CompanyContext db) : base(db)
        {

        }

        public IQueryable<UnitList> GetUnitList()
        {

            return Set().Select(x => new UnitList
            {
                UnitId = x.Id,
                UnitName = x.UnitName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == false);
        }

        public IQueryable<UnitList> RecoverUnitList()
        {

            return Set().Select(x => new UnitList
            {
                UnitId = x.Id,
                UnitName = x.UnitName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == true);
        }
    }
}
