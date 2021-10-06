using System;
using Xunit;
using Persistance;
using DAL;

namespace DALTest
{
    public class UserDalTest
    {
        private UserDal dal = new UserDal();
        private User user = new User();

        [Fact]
        public void LoginTest1()
        {
            user.UserName = "doann221";
            user.UserPassword = "Catsale123";
            var result = dal.Login(user);
            Assert.True(result);
        }

        [Theory]
        [InlineData("doann221", "Catsale123")]
        [InlineData("doann2212", "Catsale123e")]
        [InlineData("doann212", "CatSale123")]
        [InlineData("doann2213", "C")]
        [InlineData(" ", " ")]
        public void LoginTest2(string userName, string pass)
        {
            user.UserName = userName;
            user.UserPassword = pass;
            var result = dal.Login(user);
            Assert.True(result);
        }
    }
}
