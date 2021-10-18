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
            Assert.True(result != null);
        }

        [Theory]
        [InlineData("doann221", "Catsale1234")]
        [InlineData("doann2212", "Catsale123e")]
        [InlineData(" ", "CatSale123")]
        [InlineData(" ", " ")]
        public void LoginTest2(string userName, string pass)
        {
            user.UserName = userName;
            user.UserPassword = pass;
            var result = dal.Login(user);
            Assert.False(result != null);
        }
    }
}
