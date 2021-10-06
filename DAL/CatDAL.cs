using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Persistance;

namespace DAL
{ 
        public static class CatFilter
        {   
            public const int GET_ALL = 0;
           public const int FILTER_BY_ITEM_NAME = 1;
        }

  public class CatDAL
  {
    private string query;
    private MySqlConnection connection = DbConfig.GetConnection();

    public Cat GetCatByID(int CatID)
    {
      Cat cat = null;
      try
      {
        connection.Open();
        query = @"select cat_id, cat_name, cat_price
                        from Items where item_id=@itemId;";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@cat_id", CatID);
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
          cat = GetCat(reader);
        }
        reader.Close();
      }
      catch { }
      finally { connection.Close(); }
      return cat;
    }
        static  Cat GetCat(MySqlDataReader reader){
            Cat cat = new Cat();
            cat.CatID = reader.GetInt32("cat_id");
            cat.CatName = reader.GetString("cat_name");
            cat.CatPrice = reader.GetDecimal("cat_price");
            cat.CatAge = reader.GetString("cat_age");
            cat.CatColor = reader.GetString("cat_color");
            cat.CatWeight = reader.GetInt32("cat_weight");
            cat.CatLongevety = reader.GetString("cat_longevety");
            cat.CatQuantity = reader.GetInt32("cat_quantity");
            return cat;
        }

        
     public List<Cat> GetCatByName(int itemFilter, Cat cat)
    {
      List<Cat> lst = null;
       MySqlConnection connection = DbConfig.GetConnection();
      try
      {
        connection.Open();
        MySqlCommand command = new MySqlCommand("", connection);
        switch (itemFilter)
        {
          case CatFilter.GET_ALL:
            query = @"select cat_id, cat_name, unit_price from Cat";
            break;
          case CatFilter.FILTER_BY_ITEM_NAME:
            query = @"select cat_id, cat_name, unit_price from Cat
                                where item_name like concat('%',@itemName,'%');";
            command.Parameters.AddWithValue("@itemName", cat.CatName);
            break;
        }
        command.CommandText = query;
        MySqlDataReader reader = command.ExecuteReader();
        lst = new List<Cat>();
        while (reader.Read())
        {
          lst.Add(GetCat(reader));
        }
        reader.Close();
      }
      catch { }
      finally
      {
        connection.Close();
      }
      return lst;
    }
        // static public Cat GetCatByID(int catId){
        //     string query = $"select * from Cat where cat_id = {catId};";
        //     Cat cat = null;
        //     try
        //     {
        //         MySqlConnection connection = DbHelper.GetConnection();
        //         connection.Open();
        //         MySqlCommand command = connection.CreateCommand();
        //         command.CommandText = query;
        //         MySqlDataReader reader = command.ExecuteReader();
        //             if(reader.Read()){
        //                 cat = GetCat(reader);
        //             }
                
        //         reader.Close();
        //         connection.Close();
        //     }
        //     catch{
        //         Console.WriteLine("Can't connect to MySQL");
        //     }
         
        //     return cat;
        // }
    }
}
