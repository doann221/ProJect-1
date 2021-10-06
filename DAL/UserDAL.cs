using System;
using MySql.Data.MySqlClient;
using Persistance;

namespace DAL
{
    public class UserDal{
      public int Login(User user){
        int login = 0;
        
          try{
          MySqlConnection connection = DbConfig.GetConnection();
          connection.Open();
          MySqlCommand command = connection.CreateCommand();
          command.CommandText = "select * from Staffs where user_name='"+
            user.UserName+"' and user_pass='"+
            Md5Algorithms.CreateMD5(user.UserPassword)+"';";
          MySqlDataReader reader = command.ExecuteReader();
          if(reader.Read()){
            login = 1;
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
