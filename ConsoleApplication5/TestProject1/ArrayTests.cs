using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsoleApplication5;

namespace TestProject1
{
    
    [TestClass]
    public class ArrayTests
    {
        public static IEnumerable<object[]> Users
        {
            get
            {
                return new[]
                {
                    new object[] { 5, "gtrtsdv", 2 },
                    new object[] { 1, "wdsj", 1 },
                    new object[] { 1, "ugjr", 1 },
                    new object[] { 1, "kdur", 1 },
                    new object[] { 1, "obuj", 1 }
                };
            }
        }

        [TestMethod]
        public void CreateArrayUsers_True()
        {
            IUser premiumUser1 = new PremiumUser(72121, "frxd", 79);
            IUser premiumUser2 = new PremiumUser(54321, "lozqw", 42);
            IUser premiumUser3 = new PremiumUser(90183, "dgfd", 14);
            IUser regularUser1 = new RegularUser(214, "kguv", 64);
            IUser regularUser2 = new RegularUser(2342, "ffds", 23);

            Assert.IsInstanceOfType<List<IUser>>(new List<IUser>()
            {
                premiumUser1,
                premiumUser2,
                premiumUser3,
                regularUser1,
                regularUser2
            });
        }
        
        [TestMethod]
        public void CheckArrayUsersSimilarity_True()
        {
            IUser premiumUser1 = new PremiumUser(72121, "frxd", 79);
            IUser premiumUser2 = new PremiumUser(54321, "lozqw", 42);
            IUser premiumUser3 = new PremiumUser(90183, "dgfd", 14);
            IUser regularUser1 = new RegularUser(214, "kguv", 64);
            IUser regularUser2 = new RegularUser(2342, "ffds", 23);

            List<IUser> users1 = new List<IUser>
            {
                premiumUser1,
                premiumUser3,
                regularUser2,
                premiumUser2,
                regularUser1
            };
            List<IUser> users2 = new List<IUser>
            {
                regularUser2,
                regularUser1,
                premiumUser2,
                premiumUser1,
                premiumUser3
            };

            Assert.IsTrue(new HashSet<IUser>(users1).SetEquals(users2));
        }
        
        [DataTestMethod]
        [DynamicData(nameof(Users))]
        public void CheckArrayUsers_True(int balance, string name, int age)
        {
            IUser premiumUser1 = new PremiumUser(balance, name, age);
            
            Assert.IsTrue(premiumUser1.Balance > 0);
            Assert.IsTrue(premiumUser1.Name.Length > 3);
            Assert.IsTrue(premiumUser1.Age > 0);
        }
        
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void CheckError_True()
        {
            IUser premiumUser1 = new PremiumUser(-72121, "frxd", 79);
            IUser premiumUser2 = new PremiumUser(54321, "lozqw", 42);
            IUser premiumUser3 = new PremiumUser(-90183, "dgfd", 14);
            IUser regularUser1 = new RegularUser(214, "kguv", -64);
            IUser regularUser2 = new RegularUser(2342, "ffds", 23);
            
            List<IUser> users = new List<IUser>
            {
                premiumUser1,
                premiumUser3,
                regularUser2,
                premiumUser2,
                regularUser1
            };

            for (int i = 0; i < users.Count; i++)
            {
                users[i].CheckDate();
            }
        }
    }
}