using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedRepository.Repository.Classes
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        CompanyContext _db;

        public EmployeeRepository(CompanyContext db): base(db)
        {
            _db = db;
        }
        public string FullName(int id)
        {
            Employee emp = Find(id);
            return emp.FirstName + " " + emp.Surname;
        }

        public int GetAge(int id)
        {
            Employee emp = Find(id);

            var today = DateTime.Now;
            var age = today.Year - emp.DateofBirth.Year;
            var BirthDay = emp.DateofBirth.AddYears(age); //11.02.1998

            if (BirthDay > today)
            {
                age++;
            }

            return age;
        }

        public IQueryable<EmployeeList> GetEmployeeList()
        {

            return Set().Select(x => new EmployeeList
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.Surname,   //FullName(x.Id)
                Gender = x.Gender,
                Birthday = x.DateofBirth,
                Salary = x.Salary,
                ManagerName = x.Manager.FirstName + " " + x.Manager.Surname,  //Select ManagerName from Employee e inner join Employee m (m.Id == e.ManagerId)
                IsManager = x.IsManager,
                FullAddress = $"{x.Street} St., {x.Avenue} Ave., No: {x.OutDoorNumber}, County: {x.County.CountyName}",
                PhoneNumber = x.PhoneNumber,
                Deleted = x.Deleted

            }).Where(x => x.Deleted == false);
        }

        public IQueryable<ManagerList> GetManagerList()
        {

            return Set().Select(x => new ManagerList
            {
                Id = x.Id,
                Fullname = x.FirstName + " " + x.Surname,
                IsManager = x.IsManager

            }).Where(x => x.IsManager == true);
        }

        public string GetTitle(int id)
        {
            Employee emp = Find(id);
            if (emp.Gender == 'E')
            {
                return $"Mr.{emp.FirstName} {emp.Surname}" ;
            }
            else
            {
                return $"Mrs.{emp.FirstName} {emp.Surname}";
            }
        }

        public string GetFullAddress(int id)
        {
            Employee emp = Find(id);
            return $"{emp.Street} St., {emp.Avenue} Ave., No: {emp.OutDoorNumber}, Country: {emp.County.CountyName}";
        }

        public EmplooyeeDetail GetEmployeeDetail(int id)
        {
            EmplooyeeDetail employeeDetail = new EmplooyeeDetail();
            employeeDetail.Id = id;
            employeeDetail.Head = $"{GetTitle(id)} Yaşınız: {GetAge(id)}";
            return employeeDetail;

        }

        public IQueryable<EmployeeList> RecoverEmployeeList()
        {

            return Set().Select(x => new EmployeeList
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.Surname,   //FullName(x.Id)
                Gender = x.Gender,
                Birthday = x.DateofBirth,
                Salary = x.Salary,
                ManagerName = x.Manager.FirstName + " " + x.Manager.Surname,  //Select ManagerName from Employee e inner join Employee m (m.Id == e.ManagerId)
                IsManager = x.IsManager,
                FullAddress = $"{x.Street} St., {x.Avenue} Ave., No: {x.OutDoorNumber}, County: {x.County.CountyName}",
                PhoneNumber = x.PhoneNumber,
                Deleted = x.Deleted

            }).Where(x => x.Deleted == true);
        }
    }
}
