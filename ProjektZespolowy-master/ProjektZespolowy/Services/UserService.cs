using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektZespolowy.Models;

namespace ProjektZespolowy.Services
{
    public class UserService : IUserService

    {
        private AppContext _context;

        public UserService(AppContext context)
        {
            _context = context;
        }



        public ICollection<User> GetUserList()
        {
            var usersFromRepo = _context.Users.ToList();

            return usersFromRepo;

        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            var userFromRepo = _context.Users.FirstOrDefault(u => u.Id == id);

            return userFromRepo;

        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var userFromRepo = GetUserById(id);
            _context.Users.Remove(userFromRepo);
            _context.SaveChanges();
        }
    }
}
