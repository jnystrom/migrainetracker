using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gazallion.MigraineManager.Data.SqlServer;
using Gazallion.MigraineManager.Data.SqlServer.Models;
using Gazallion.MigraineManager.Data.Models;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EFRepository<GazallionMigraineDataDbContext> repo = new EFRepository<GazallionMigraineDataDbContext>();
            Medicine test = repo.Insert<Medicine>(new Medicine
            {
                MedType = new MedType
                {
                    Type = "daily"
                },
                Name = "Topomax",
                

            });
            

        }

        [TestMethod]
        public void InsertUserTest()
        {
            EFRepository<GazallionMigraineDataDbContext> repo = new EFRepository<GazallionMigraineDataDbContext>();
            User test = repo.Insert<User>(new User
            {
                FirstName = "John",
                LastName = "Nystrom",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Alpharetta",
                        Region = "GA",
                        ZipCode = "30004",
                        StreetName = "Montgomery Ave",
                        StreetNumber = "123"
                    }
                },
                EmailAddress = "jnystrom2@live.com",
                UserConditions = new List<UserCondition>
                {
                    new UserCondition
                    {
                        Condition = new Condition
                        {
                            Name = "Migraine",
                            Description = "bad headaches"
                        },
                        IncidentThreshold = 9,
                        ThresholdTimePeriod = (int)ThresholdTimePeriod.Monthly
                    }
                }
            });
        }
    }
}
