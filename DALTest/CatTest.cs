using System;
using Xunit;
using Persistance;
using DAL;

namespace CatTest
{
    public class CatDalTest
    {
        private CatDAL dal = new CatDAL();
        private Cat cat = new Cat();

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(25)]
        public void SearchByID_Test1(int id)
        {
            cat.CatID = id;
            var result = dal.GetCatByID(id);
            Assert.True(result != null);
            Assert.True(result.CatID == id);
        }
        [Theory]
        [InlineData("Mèo Bombay")]
        [InlineData("Mèo  Himalayan")]
        [InlineData("Mèo Java")]
        [InlineData("Mèo Pixi Bob")]
        public void SearchByName_Test1(string name)
        {
            cat.CatName=name;
            var result = dal.GetCatByName(1, cat);
            Assert.Equals(result, cat.CatName = name);
        }
        [Theory]
        [InlineData("meo con")]
        [InlineData("meo me")]
        [InlineData("meo beo")]
        [InlineData("meo khong long")]
        [InlineData("cho")]
        public void SearchByName_Test2(string name)
        {
            cat.CatName = name;
            var result  = dal.GetCatByName(1, cat);
            Assert.NotEaqual(result,cat.CatName = name);
        }
        
    }
}
