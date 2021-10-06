using System;

namespace Persistance
{
    public class Customer
    {
        public int? CustomerId {set;get;}
        public string CustomerName {set;get;}
        public string CustomerAddress{set;get;}

        public override bool Equals(object obj){
            if(obj is Customer){
                return ((Customer)obj).CustomerId.Equals(CustomerId);
            }
            return false;
        }

        public override int GetHashCode(){
            return CustomerId.GetHashCode();
        }
    }
}