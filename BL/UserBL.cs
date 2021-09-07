using System;
using Persistance;
using DAL;

namespace BL
{
    public class UserBl
    {
        private UserDAL dal = new UserDAL();
        public int Login(User user){
            return dal.login(user);
        }
    }
}
