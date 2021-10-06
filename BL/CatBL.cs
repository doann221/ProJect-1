using System;
using Persistance;
using System.Collections.Generic;
using DAL;

namespace BL
{
    public class CatBL{
       private CatDAL cdal = new CatDAL();
        public Cat GetCatByID(int catId)
        {
            return cdal.GetCatByID(catId);
        }
        public List<Cat> GetAll()
        {
            return cdal.GetCatByName(CatFilter.GET_ALL, null);
        }
        public List<Cat> GetByName(string catName)
        {
            return cdal.GetCatByName(CatFilter.FILTER_BY_ITEM_NAME, new Cat{CatName=catName});
        }
    }
}