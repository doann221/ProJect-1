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
                query = @"select *
                        from Cat where cat_id=@CatId;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CatID", CatID);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    cat = GetCat(reader);
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return cat;
        }
        internal Cat GetCat(MySqlDataReader reader)
        {
            Cat cat = new Cat();
            cat.CatID = reader.GetInt32("cat_id");
            cat.CatName = reader.GetString("cat_name");
            cat.CatPrice = reader.GetDecimal("cat_price");
            cat.CatAge = reader.GetString("cat_age");
            cat.CatColor = reader.GetString("cat_color");
            cat.CatWeight = reader.GetString("cat_weight");
            cat.CatLongevety = reader.GetString("cat_longevety");
            cat.CatQuantity = reader.GetInt32("cat_quantity");
            return cat;
        }


        public List<Cat> GetCatByName(int itemFilter, Cat cat)
        {
            List<Cat> lst = null;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("", connection);
                switch (itemFilter)
                {
                    case CatFilter.GET_ALL:
                        query = @"select* from Cat";
                        break;
                    case CatFilter.FILTER_BY_ITEM_NAME:
                        query = @"select * from Cat
                                where cat_name like concat('%',@catName,'%');";
                        command.Parameters.AddWithValue("@catName", cat.CatName);
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

    }
}
