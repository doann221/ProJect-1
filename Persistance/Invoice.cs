using System;
using System.Collections.Generic;

namespace Persistance
{
    public static class InvoiceStatus
    {
        public const int CREATE_NEW_INVOICE= 1;
        public const int ORDER_INPROGRESS = 2;
    }
    public class Invoice
    {
        public int InvoiceID { set; get; }
        public DateTime OrderDate { set; get; }
        public Customer OrderCustomer { set; get; }
        public User OrderUser{set; get;}
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

        public Invoice()
        {
            CatList = new List<Cat>();
            OrderCustomer = new Customer();
            OrderDate = DateTime.Now;
        }

        public override bool Equals(object obj){
            if(obj is Invoice){
                return ((Invoice)obj).InvoiceID.Equals(InvoiceID);
            }
            return false;
        }

        public override int GetHashCode(){
            return InvoiceID.GetHashCode();
        }
    }
}