using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Persistance;

namespace DAL
{
    public class CatDAL{
        static protected Cat GetCat(MySqlDataReader reader){
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

        static public Cat GetCatByID(int catId){
            string query = $"select * from Cat where cat_id = {catId};";
            Cat cat = null;
            try
            {
                MySqlConnection connection = DbHelper.GetConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                    if(reader.Read()){
                        cat = GetCat(reader);
                    }
                
                reader.Close();
                connection.Close();
            }
            catch{
                Console.WriteLine("Can't connect to MySQL");
            }
         
            return cat;
        }
        static public Cat GetCatByName(int CatName){
            string query = $"select * from Cat where cat_name = {CatName};";
            Cat cat = null;
            try
            {
                MySqlConnection connection = DbHelper.GetConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                    if(reader.Read()){
                        cat = GetCat(reader);
                    }
                
                reader.Close();
                connection.Close();
            }
            catch{
                Console.WriteLine("Can't connect to MySQL");
            }
         
            return cat;
        }
    }
}