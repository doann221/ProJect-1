using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistance;

namespace DAL
{
    public class InvoiceDAL
    {
        private MySqlConnection connection = DbConfig.GetConnection();
        public bool CreateInvoice(Invoice invoice)
        {
            if (invoice == null || invoice.CatList == null || invoice.CatList.Count == 0)
            {
                return false;
            }
            bool result = false;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                //Lock update all tables
                cmd.CommandText = "lock tables Customers write, Invoices write, Cat write, InvoiceDetail write;";
                cmd.ExecuteNonQuery();
                MySqlTransaction trans = connection.BeginTransaction();
                cmd.Transaction = trans;
                MySqlDataReader reader = null;
                if (invoice.OrderCustomer == null || invoice.OrderCustomer.CustomerName == null || invoice.OrderCustomer.CustomerName == "")
                {
                    //set default customer with customer id = 1
                    invoice.OrderCustomer = new Customer() { CustomerId = 1 };
                }
                try
                {
                    if (invoice.OrderCustomer.CustomerId == null)
                    {
                        //Insert new Customer
                        cmd.CommandText = @"insert into Customers(customer_name, customer_address , customer_Phone)
                            values ('" + invoice.OrderCustomer.CustomerName + "','" + (invoice.OrderCustomer.CustomerAddress ?? "") + "', '" + invoice.OrderCustomer.CustomerPhone + "');";
                        cmd.ExecuteNonQuery();
                        //Get new customer id
                        cmd.CommandText = "select customer_id from Customers order by customer_id desc limit 1;";
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            invoice.OrderCustomer.CustomerId = reader.GetInt32("customer_id");
                        }
                        reader.Close();
                    }
                    else
                    {
                        //get Customer by Id
                        cmd.CommandText = "select * from Customers where customer_id=@customerId;";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@customerId", invoice.OrderCustomer.CustomerId);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            invoice.OrderCustomer = new CustomerDAL().GetCustomer(reader);
                        }
                        reader.Close();
                    }
                    if (invoice.OrderCustomer == null || invoice.OrderCustomer.CustomerId == null)
                    {
                        throw new Exception("Can't find Customer!");
                    }
                    //Insert invoice
                    cmd.CommandText = "insert into Invoices(customer_id, invoice_status,user_id) values (@customerId, @invoiceStatus, @userId);";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@customerId", invoice.OrderCustomer.CustomerId);
                    cmd.Parameters.AddWithValue("@userId", invoice.OrderUser.UserID);
                    cmd.Parameters.AddWithValue("@invoiceStatus", InvoiceStatus.CREATE_NEW_INVOICE);
                    cmd.ExecuteNonQuery();
                    //get new invoice_no
                    cmd.CommandText = "select LAST_INSERT_ID() as invoice_id";
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        invoice.InvoiceID = reader.GetInt32("invoice_id");
                    }
                    reader.Close();

                    //insert invoice Details table
                    foreach (var cat in invoice.CatList)
                    {
                        if (cat.CatID == null || cat.CatQuantity <= 0)
                        {
                            throw new Exception("Not Exists Cat");
                        }
                        //get unit_price
                        cmd.CommandText = "select cat_price from Cat where cat_id=@catId";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@CatId", cat.CatID);
                        reader = cmd.ExecuteReader();
                        if (!reader.Read())
                        {
                            throw new Exception("Not Exists Cat");
                        }
                        cat.CatPrice = reader.GetDecimal("cat_price");
                        reader.Close();

                        //insert to Order Details
                        cmd.CommandText = @"insert into InvoiceDetails(invoice_id, cat_id, cat_price, cat_quantity) values 
                            (" + invoice.InvoiceID + ", " + cat.CatID + ", " + cat.CatPrice + ", " + cat.CatQuantity + ");";
                        cmd.ExecuteNonQuery();

                        //update quantity in Cats
                        cmd.CommandText = "update Cat set quantity=quantity-@quantity where cat_id=" + cat.CatID + ";";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@quantity", cat.CatQuantity);
                        cmd.ExecuteNonQuery();
                    }
                    //commit transaction
                    trans.Commit();
                    result = true;
                }
                catch
                {
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                }
                finally
                {
                    //unlock all tables;
                    cmd.CommandText = "unlock tables;";
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}