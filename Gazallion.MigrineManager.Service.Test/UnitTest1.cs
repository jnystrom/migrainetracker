using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gazallion.MigraineManager.Data.I;
using Gazallion.MigraineManager.Data.SqlServer;
using Gazallion.MigraineManager.Data.Models;
using Gazallion.MigraineManager.Service;
using Gazallion.MigraineManager.Service.I;
using Gazallion.MigraineManager.Data.SqlServer.Models;

namespace Gazallion.MigrineManager.Service.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRepository repo = new EFRepository<GazallionMigraineDataDbContext>();
            IUserService userService = new UserService(repo);
            var users = userService.GetUsers();
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Any());
        }
    }
}
