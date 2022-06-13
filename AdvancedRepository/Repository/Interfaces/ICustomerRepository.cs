using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRepository.Repository.Interfaces
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        IQueryable<CustomerList> GetCustomerList();
        IQueryable<CustomerList> RecoverCustomerList();
        IQueryable<CustomerSelect> GetCustomerSelect();
    }
}
