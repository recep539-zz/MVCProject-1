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
    public class FatMasterRepository : BaseRepository<FatMaster>, IFatMasterRepository
    {
        CompanyContext _db;
        public FatMasterRepository(CompanyContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<FatMasterList> GetFatMaster()
        {
            return Set().Select(x => new FatMasterList
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Date = x.Date,
                CompanyName = x.Customer.CompanyName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == false);
        }
        public IQueryable<FatMasterList> GetRecoverFatMaster()
        {
            return Set().Select(x => new FatMasterList
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Date = x.Date,
                CompanyName = x.Customer.CompanyName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == true);
        }
    }
}
