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
    public class SupplierRepository: BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(CompanyContext db): base(db)
        {

        }

        public IQueryable<SupplierList> GetSupplierList()
        {

            return Set().Select(x => new SupplierList
            {
                SupplierId = x.Id,
                CompanyName = x.CompanyName,
                FullAddress = $"{x.Street} St., {x.Avenue} Ave., No: {x.OutDoorNumber}, Country: {x.County.CountyName}",
                PhoneNumber = x.PhoneNumber,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == false);
        }

        public IQueryable<SupplierList> RecoverSupplierList()
        {

            return Set().Select(x => new SupplierList
            {
                SupplierId = x.Id,
                CompanyName = x.CompanyName,
                FullAddress = $"{x.Street} St., {x.Avenue} Ave., No: {x.OutDoorNumber}, Country: {x.County.CountyName}",
                PhoneNumber = x.PhoneNumber,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == true);
        }
    }
}
