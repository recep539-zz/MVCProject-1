using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRepository.Repository.Interfaces
{
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
        IQueryable<EmployeeList> GetEmployeeList();
        IQueryable<EmployeeList> RecoverEmployeeList();
        string GetTitle(int id);
        int GetAge(int id);
        string FullName(int id);
        IQueryable<ManagerList> GetManagerList();
        EmplooyeeDetail GetEmployeeDetail(int id);

    }
}
