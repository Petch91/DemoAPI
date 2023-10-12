using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public interface IUserService 
   {
      bool Register(string email, string password, string userName);
      User Login(string email, string password);
      IEnumerable<User> ReadAll();
      User ReadOne(int id);
   }
}
