// using Xunit;
// using Persistance;
// using DAL;
// using System.Collections.Generic;

// namespace DALTest
// {
//     public class InvoiceDALTest
//     {
//         private InvoiceDAL invoiceDAL = new InvoiceDAL();
//         private Invoice invoice = new Invoice();
        
//         [Fact]
//         public void CreateInvoice_Test1()
//         {              
//             Invoice invoice = new Invoice()
//             {
//                 OrderCustomer = new Customer { CustomerName = "Nguyen A", CustomerPhone = "0326485136"},
//                 OrderUser = new User { UserID = 1},
//                 CatList =
//                 {
//                     new Cat { CatID = 15, CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 23, CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 36, CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 32, CatList = new CatTable() {CatQuantity = 1}}
//                 }
//             };
//             var result = invoiceDAL.CreateInvoice(invoice);
//             Assert.True(result);
//         }

//         [Fact]
//         public void CreateInvoice_Test2()
//         {              
//             Invoice invoice = new Invoice()
//             {
//                 OrderCustomer = new Customer { CustomerName = "Nguyen B", CustomerPhone = "0854692136"},
//                 OrderUser = new User     { UserID = 1},
//                 CatList =
//                 {
//                     new Cat { CatID = 1,  CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 12, CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 23, CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 45, CatList = new CatTable() {CatQuantity = 1}}
//                 }
//             };
//             var result = invoiceDAL.CreateInvoice(invoice);
//             Assert.True(result);
//         }

//         [Fact]
//         public void CreateInvoice_Test3()
//         {              
//             Invoice invoice = new Invoice()
//             {
//                 OrderCustomer = new Customer { CustomerName = "Tran Thi Ngu", CustomerPhone = "0126425813"},
//                 OrderUser = new Seller { UserID = 1},
//                 CatList =
//                 {
//                     new Cat { CatID = 10, CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 20, CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 30, CatList = new CatTable() {CatQuantity = 1}},
//                     new Cat { CatID = 40, CatList = new CatTable() {CatQuantity = 1}}
//                 }
//             };
//             var result = invoiceDAL.CreateInvoice(invoice);
//             Assert.True(result);
//         }

//         [Fact]
//         public void CreateInvoice_Test4()
//         {
//             Invoice invoice = new Invoice()
//             {
//                 OrderCustomer = new Customer { CustomerName = "Nguyen C", CustomerPhone = "0326486936"},
//                 OrderUser = new User { UserID = 1},
//                 CatList =
//                 {
//                     new Cat { CatID = 0, CatList = new CatTable() {CatQuantity = 6}},
//                     new Cat { CatID = 100, CatList = new CatTable() {CatQuantity = 15}},
//                     new Cat { CatID = 3564, CatList = new CatTable() {CatQuantity = 26}},
//                     new Cat { CatID = 2, CatList = new CatTable() {CatQuantity = 600}}
//                 }
//             };
//             var result = invoiceDAL.CreateInvoice(invoice);
//             Assert.False(result);
//         }
//     }
// }