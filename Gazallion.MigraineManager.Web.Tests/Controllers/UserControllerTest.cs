using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gazallion.MigraineManager.Web;
using Gazallion.MigraineManager.Web.Controllers;
using Gazallion.MigraineManager.Data.Models;
using Gazallion.MigraineManager.Service;
using Gazallion.MigraineManager.Data.SqlServer;
using Gazallion.MigraineManager.Data.SqlServer.Models;
using Gazallion.MigraineManager.Common.Data.DTOs;

namespace Gazallion.MigraineManager.Web.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            UserController controller = new UserController(new UserService(new EFRepository<GazallionMigraineDataDbContext>()));

            // Act
            IEnumerable<User> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            UserController controller = new UserController(new UserService(new EFRepository<GazallionMigraineDataDbContext>()));

            // Act
            UserDto result = controller.Get(0);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            UserController controller = new UserController(new UserService(new EFRepository<GazallionMigraineDataDbContext>()));

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            UserController controller = new UserController(new UserService(new EFRepository<GazallionMigraineDataDbContext>()));

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            UserController controller = new UserController(new UserService(new EFRepository<GazallionMigraineDataDbContext>()));

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
