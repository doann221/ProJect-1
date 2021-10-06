using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistance;

namespace DAL
{
  public class OrderDAL
  {
    private MySqlConnection connection = DbConfig.GetConnection();
    public bool CreateOrder(Order order)
    {
      if (order == null || order.CatList == null || order.CatList.Count == 0)
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
        cmd.CommandText = "lock tables Customers write, Orders write, Items write, OrderDetails write;";
        cmd.ExecuteNonQuery();
        MySqlTransaction trans = connection.BeginTransaction(); 
        cmd.Transaction = trans;
        MySqlDataReader reader = null;
        if (order.OrderCustomer == null || order.OrderCustomer.CustomerName == null || order.OrderCustomer.CustomerName == "")
        {
          //set default customer with customer id = 1
          order.OrderCustomer = new Customer() { CustomerId = 1 };
        }
        try
        {
          if (order.OrderCustomer.CustomerId == null)
          {
            //Insert new Customer
            cmd.CommandText = @"insert into Customers(customer_name, customer_address)
                            values ('" + order.OrderCustomer.CustomerName + "','" + (order.OrderCustomer.CustomerAddress ?? "") + "');";
            cmd.ExecuteNonQuery();
            //Get new customer id
            cmd.CommandText = "select customer_id from Customers order by customer_id desc limit 1;";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
              order.OrderCustomer.CustomerId = reader.GetInt32("customer_id");
            }
            reader.Close();
          }
          else
          {
            //get Customer by Id
            cmd.CommandText = "select * from Customers where customer_id=@customerId;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@customerId", order.OrderCustomer.CustomerId);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
              order.OrderCustomer = new CustomerDAL().GetCustomer(reader);
            }
            reader.Close();
          }
          if (order.OrderCustomer == null || order.OrderCustomer.CustomerId == null)
          {
            throw new Exception("Can't find Customer!");
          }
          //Insert Order
          cmd.CommandText = "insert into Orders(customer_id, order_status) values (@customerId, @orderStatus);";
          cmd.Parameters.Clear();
          cmd.Parameters.AddWithValue("@customerId", order.OrderCustomer.CustomerId);
          cmd.Parameters.AddWithValue("@orderStatus", OrderStatus.CREATE_NEW_ORDER);
          cmd.ExecuteNonQuery();
          //get new Order_ID
          cmd.CommandText = "select LAST_INSERT_ID() as order_id";
          reader = cmd.ExecuteReader();
          if (reader.Read())
          {
            order.OrderId = reader.GetInt32("order_id");
          }
          reader.Close();

          //insert Order Details table
          foreach (var cat in order.CatList)
          {
            if (cat.CatID == null || cat.CatQuantity <= 0)
            {
              throw new Exception("Not Exists Item");
            }
            //get unit_price
            cmd.CommandText = "select unit_price from Items where item_id=@itemId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@itemId", cat.CatID);
            reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
              throw new Exception("Not Exists Item");
            }
            cat.CatPrice = reader.GetDecimal("unit_price");
            reader.Close();

            //insert to Order Details
            cmd.CommandText = @"insert into OrderDetails(order_id, item_id, unit_price, quantity) values 
                            (" + order.OrderId + ", " + cat.CatID + ", " + cat.CatPrice + ", " + cat.CatQuantity + ");";
            cmd.ExecuteNonQuery();

            //update amount in Items
            cmd.CommandText = "update Items set amount=amount-@quantity where item_id=" +cat.CatID + ";";
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