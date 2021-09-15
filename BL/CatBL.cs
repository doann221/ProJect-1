using System;
using Persistance;
using System.Collections.Generic;
using DAL;

namespace BL
{
    public class CatBL{
        public Cat SearchCatByID(int catID){
            return CatDAL.GetCatByID(catID);
        }
        public Cat SearchCatByName(int catName){
            return CatDAL.GetCatByName(catName);
        }
    }
}