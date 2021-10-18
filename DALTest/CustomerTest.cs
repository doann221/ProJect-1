using System;
using Xunit;
using Persistance;
using DAL;

namespace DALTest
{
    public class CustomerDALTest
    {
        private Customer customer = new Customer();
        private CustomerDAL customerDAL = new CustomerDAL();
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetCustomerID_TestTrue(int customer_id)
        {
            customer.CustomerId = customer_id;
            var result = customerDAL.GetById(customer_id);
            Assert.True(result != null);
            Assert.True(result.CustomerId == customer_id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(150)]
        [InlineData(200)]
        [InlineData(250)]
        public void GetCustomerID_TestFalse(int customer_id)
        {
            customer.CustomerId = customer_id;
            var result = customerDAL.GetById(customer_id);
            Assert.False(result != null);
        }

    }
}