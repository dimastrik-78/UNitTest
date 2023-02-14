using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApplication5;

namespace TestProject1
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CreateUsers_True()
        {
            Assert.IsInstanceOfType<IUser>(new PremiumUser(5421, "dgfd", 54));
            Assert.IsInstanceOfType<IUser>(new RegularUser(234, "ffds", 23));
        }
        
        [TestMethod]
        public void CheckUsers_True()
        {
            IUser premiumUser = new PremiumUser(5421, "dgfd", 54);
            IUser regularUser = new RegularUser(234, "ffds", 23);
            
            Assert.IsTrue(premiumUser.Balance >= 0
                        && premiumUser.Name.Length > 3
                        && premiumUser.Age >= 0
                        && premiumUser.DateRegistration != default
                        && regularUser.Balance >= 0
                        && regularUser.Name.Length > 3
                        && regularUser.Age >= 0
                        && regularUser.DateRegistration != default);
            
        }
        
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void CheckError_True()
        {
            IUser premiumUser2 = new PremiumUser(-52, "d", -9);
            premiumUser2.CheckDate();
        }
    }
}