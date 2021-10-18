using System;
using Xunit;
using Persistance;
using DAL;

namespace DALTest
{
    public class CatTest
    {
        private CatDAL dal = new CatDAL();
        private Cat cat = new Cat();

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(12)]
        [InlineData(25)]
        [InlineData(30)]
        public void SearchByID_TestTrue(int catId)
        {
            cat.CatID = catId;
            var result = dal.GetCatByID(catId);
            Assert.True(result != null);
            Assert.True(result.CatID == catId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(75)]
        [InlineData(513)]
        [InlineData(100)]
        [InlineData(99)]
        public void SearchByID_TestFalse(int catId)
        {
            cat.CatID = catId;
            var result = dal.GetCatByID(catId);
            Assert.True(result == null);
        }

        [Theory]
        [InlineData(" British Longhair Cat")]
        [InlineData(" Ragdoll")]
        [InlineData(" Abyssinian")]
        [InlineData(" Birman")]
        [InlineData(" Java")]
        public void SearchByName_TestTrue(string name)
        {
            cat.CatName = name;
            var result = dal.GetCatByName(1, cat);
            Assert.Contains(result, cat => cat.CatName == name);
        }

        [Theory]
        [InlineData("meo ngu")]
        [InlineData("meo con")]
        [InlineData("meo trui long")]
        [InlineData("sieu meo")]
        [InlineData("meo bo")]
        public void SearchByName_TestFalse(string name)
        {
            cat.CatName = name;
            var result = dal.GetCatByName(1, cat);
            Assert.DoesNotContain(result, cat => cat.CatName == name);
        }
    }
}
