using DAL.Domains;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
   public class UserService : IUserService
   {
      private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User Login(string email, string password)
      {
         User user = _context.users.SingleOrDefault(x => x.Email == email);

         if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            throw new Exception("Username or password is incorrect");
         return user;
      }

      public IEnumerable<User> ReadAll()
      {
         return _context.users;
      }

      public User ReadOne(int id)
      {
         return _context.users.SingleOrDefault(u => u.UserId == id);
      }

      public bool Register(string email, string password, string userName)
      {
         if (_context.users.Where(u => u.Email == email).Count() == 0 && _context.users.Where(u => u.UserName == userName).Count() == 0)
         {
            _context.users.Add(new User { Email = email, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password), UserName = userName });
            _context.SaveChanges();
            return true;
         }
         else return false;
      }

   }
}
