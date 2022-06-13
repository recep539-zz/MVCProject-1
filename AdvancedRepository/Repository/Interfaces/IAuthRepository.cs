using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Interfaces
{
    public interface IAuthRepository// base den miras almadık özel bir repos tanımı bu
    {
        void Register(string UserName,string Password);
        Users Login(string UserName, string Password);
        void LogOut();
    }
}
