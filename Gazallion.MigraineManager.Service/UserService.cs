using Gazallion.MigraineManager.Data.I;
using Gazallion.MigraineManager.Data.Models;
using Gazallion.MigraineManager.Service.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazallion.MigraineManager.Service
{
    public class UserService : IUserService
    {
        private IRepository _Repo;

        public UserService(IRepository userRepository )
        {
            _Repo = userRepository;
        }
        public IEnumerable<Gazallion.MigraineManager.Data.Models.User> GetUsers()
        {
            return _Repo.Select<User>();
        }

        public User GetUser(int userId)
        {
            var includes = new string[] {"UserMeds", "Addresses", "UserMeds", "UserConditions", "UserConditions.Condition"};

            var temp =  _Repo.Select<User>(whereClause: user => user.UserId == userId, include:includes);

            return temp.FirstOrDefault();

        }

        public Gazallion.MigraineManager.Data.Models.User AddUser(Gazallion.MigraineManager.Data.Models.User userToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
