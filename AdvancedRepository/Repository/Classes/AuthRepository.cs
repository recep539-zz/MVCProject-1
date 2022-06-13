using AdvancedRepository.Core;
using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class AuthRepository :IAuthRepository
    {
        
        Users _users;
        CompanyContext _db;

        public AuthRepository(Users users,CompanyContext db)
        {
            
            _users = users;
            _db = db;
        }
        public Users Login(string UserName, string Password)
        {
           var user= _db.Set<Users>().Find(UserName);
            if (UserName!=null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(Password, user.Password);
                if (verified)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public void Register(string UserName, string Password)
        {
            _users.UserName = UserName;
            _users.Password = BCrypt.Net.BCrypt.HashPassword(Password);//Admin bile paraloyu göremesin diye.Güvenlik için yapıldı.
            _users.Role = "User";
            _db.Set<Users>().Add(_users);
            _db.SaveChanges();   
        }
    }
}
