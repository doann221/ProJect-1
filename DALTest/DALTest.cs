using System;
using Xunit;
using Persistance;
using DAL;

namespace DALTest
{
    public class UserDalTest
    {
        private UserDAL dal = new UserDAL();
        private User user = new User();

        [Fact]
        public void LoginTest1()
        {
            user.UserName = "doann221";
            user.UserPassword = "PF13VTCAcademy";
            int expected = 1;
            int result = dal.login(user);
            Assert.True(expected == result);
        }

        [Theory]
        [InlineData("doann221", "PF13VTCAcademy", 1)]
        [InlineData("doann212", "PF13VTCAcademy", 0)]     
        [InlineData("doann221", "PF13VTCAcademysdf", 0)]
        public void LoginTest2(string userName, string pass, int expected){
            user.UserName = userName;
            user.UserPassword = pass;
            int result = dal.login(user);
            Assert.True(expected == result);
        }
    }
}
