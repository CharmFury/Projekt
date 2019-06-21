using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektZespolowy.Models;

namespace ProjektZespolowy.Services
{
    public interface IUserService
    {
        ICollection<User> GetUserList();
        void AddUser(User user);
        User GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
