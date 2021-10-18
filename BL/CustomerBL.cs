using System;
using System.Collections.Generic;
using Persistance;
using DAL;

namespace BL
{
    public class CustomerBL
    {
        private CustomerDAL csdal = new CustomerDAL();
        public Customer GetById(int customerId)
        {
            return csdal.GetById(customerId);
        }

        public int AddCustomer(Customer customer)
        {
            return csdal.AddCustomer(customer) ?? 0;
        }
    }
}