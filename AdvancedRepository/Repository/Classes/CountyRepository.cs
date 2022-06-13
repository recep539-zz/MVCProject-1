using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRepository.Repository.Classes
{
    public class CountyRepository: BaseRepository<County>, ICountyRepository
    {
        public CountyRepository(CompanyContext db): base(db)
        {

        }

        public IQueryable<CountyList> GetCountyList()
        {

            return Set().Select(x => new CountyList
            {
                CountyId = x.Id,
                CountyName = x.CountyName,
                Deleted = x.Deleted

            }).Where(x => x.Deleted == false);
        }

        public IQueryable<CountyList> ListByCityId(int id)
        {

            return Set().Select(x => new CountyList
            {
                CountyId = x.Id,
                CountyName = x.CountyName,
                CityId = x.CityId
            }).Where(x => x.CityId == id);
        }

        public IQueryable<CountyList> RecoverCountyList()
        {

            return Set().Select(x => new CountyList
            {
                CountyId = x.Id,
                CountyName = x.CountyName,
                Deleted = x.Deleted

            }).Where(x => x.Deleted == true);
        }
    }
}
