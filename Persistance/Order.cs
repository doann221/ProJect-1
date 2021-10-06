using System;
using System.Collections.Generic;

namespace Persistance
{
    public static class OrderStatus
    {
        public const int CREATE_NEW_ORDER = 1;
        public const int ORDER_INPROGRESS = 2;
    }
    public class Order
    {
        public int OrderId { set; get; }
        public DateTime OrderDate { set; get; }
        public Customer OrderCustomer { set; get; }
        public int? Status {set;get;}
        public List<Cat> CatList { set; get; }

        public Cat this[int index]
        {
            get
            {
                if (CatList == null || CatList.Count == 0 || index < 0 || CatList.Count < index) return null;
                return CatList[index];
            }
            set
            {
                if (CatList == null) CatList = new List<Cat>();
                CatList.Add(value);
            }
        }

        public Order()
        {
            CatList = new List<Cat>();
        }

        public override bool Equals(object obj){
            if(obj is Order){
                return ((Order)obj).OrderId.Equals(OrderId);
            }
            return false;
        }

        public override int GetHashCode(){
            return OrderId.GetHashCode();
        }
    }
}