using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRepository.Repository.Classes
{
    public class CityRepository: BaseRepository<City>, ICityRepository
    {
        public CityRepository(CompanyContext db): base(db)
        {

        }

        public IQueryable<CityList> GetCityList()
        {

            return Set().Select(x => new CityList
            {
                CityId = x.Id,
                CityName = x.CityName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == false);
        }

        public IQueryable<CityList> RecoverCityList()
        {
            
            return Set().Select(x => new CityList
            {
                CityId = x.Id,
                CityName = x.CityName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == true);
        }
    }
}
