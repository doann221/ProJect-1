using System;
using MySql.Data.MySqlClient;
using Persistance;

namespace DAL
{
    public class UserDAL
    {
        public int login(User user)
        {
            int login= 0;
          try{
          MySqlConnection connection = DbHelper.GetConnection();
          connection.Open();
          MySqlCommand command = connection.CreateCommand();
          command.CommandText = "select * from user where user_name='"+
            user.UserName+"' and user_pass='"+
            Md5Algorithms.CreateMD5(user.UserPassword)+"';";
          MySqlDataReader reader = command.ExecuteReader();
          if(reader.Read()){
            login = reader.GetInt32("role");
          }else
          {
              login = 0;
          }
          reader.Close();
          connection.Close();
        }catch{
          login = -1;
        }
        return login;
      }
    }
}
