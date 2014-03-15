using Gazallion.MigraineManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazallion.MigraineManager.Service.I
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int userId);
        User AddUser(User userToAdd);
    }
}
