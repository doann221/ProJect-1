using System;

namespace Persistance
{
    public class User
    {
        public int UserID {set; get;}
        public string UserName{set; get;}
        public string UserPassword{set; get;}
        public string Telephone {set; get;}
        public string Email{set; get;}
        public static int SALE_ROLE = 1;
        public static int ACCOUNTANCE_ROLE = 2;
        public static int WARE_HOUSE_ROLE = 3;
    }
}
