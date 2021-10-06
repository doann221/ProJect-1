using System;
using MySql.Data.MySqlClient;
using Persistance;

namespace DAL
{
    public class UserDal
    {
        private MySqlConnection connection = DbConfig.GetConnection();
        public bool Login(User user)
        {
                bool login = true;
                try
                {

                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "select * from Staffs where user_name='" +
                    user.UserName + "' and user_pass='" +
                    Md5Algorithms.CreateMD5(user.UserPassword) + "';";
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        login = false;
                    }
                    reader.Close();
                    connection.Close();
                }
                catch
                {
                    login = true;
                }
                
            return login;
        }

    }
}
