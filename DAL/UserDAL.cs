using System;
using MySql.Data.MySqlClient;
using Persistance;

namespace DAL
{
    public class UserDal
    {
        private MySqlConnection connection = DbConfig.GetConnection();
        public User Login(User user)
        {
            User user1 = null;
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
                    user1 = GetUser(reader);
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return user1;
        }
        internal User GetUser(MySqlDataReader reader)
        {
            User user = new User();
            user.UserID = reader.GetInt32("staff_id");
            user.UserName = reader.GetString("user_name");
            return user;
        }
    }
}
