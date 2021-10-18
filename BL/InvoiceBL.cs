using System;
using System.Collections.Generic;
using Persistance;
using DAL;

namespace BL
{
    public class InvoiceBL
    {
        private static InvoiceDAL odl = new InvoiceDAL();
        public static bool CreateInvoice(Invoice invoice)
        {
            bool result = odl.CreateInvoice(invoice);
            return result;
        }
    }
}