using System;

namespace Persistance
{
    public class Cat
    {
        public static class CatStatus
        {
            public const int NOT_ACTIVE = 0;
            public const int ACTIVE = 1;
        }
        public int? CatID { set; get; }
        public string CatName { set; get; }
        public decimal CatPrice { set; get; }
        public string CatAge { set; get; }
        public string CatColor { set; get; }
        public string CatWeight { set; get; }
        public string CatLongevety { set; get; }
        public int CatQuantity { set; get; }

        public override bool Equals(object obj)
        {
            if (obj is Cat)
            {
                return ((Cat)obj).CatID.Equals(CatID);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CatID.GetHashCode();
        }
    }
}
