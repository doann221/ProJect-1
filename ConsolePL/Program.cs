using System;
using Persistance;
using BL;
using System.Text;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine();
            UserBL bl = new UserBL();
            string logo = @"
                            ╦        ╔═══════╗   ╔═════      ╦  ╦       ╦    
                            ║        ║       ║   ║           ║  ║ \     ║ 
                            ║        ║       ║   ║           ║  ║  \    ║ 
                            ║        ║       ║   ║    ══╦═   ║  ║   \   ║ 
                            ║        ║       ║   ║      ║    ║  ║    \  ║ 
                            ║    ╦   ║       ║   ║      ║    ║  ║     \ ║ 
                            ╩════╝   ╚═══════╝   ╚══════╝    ╩  ╩       ╩ ";
        
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" " + dateTime);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(logo);
                display(15,10, "User Name:" );
                string userName = Console.ReadLine();
                display(15,11 ,"Password: ");
                string pass = GetPassword();
                Console.WriteLine();
                User user = new User() { UserName = userName, UserPassword = pass };
                bool login = bl.Login(user);
                if (login == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("User Name or password incorrect!! Please Input again!!");
                    Console.ReadLine(); 
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Logged in successfully");
                    Console.Clear();
                    Menu.MainMenu();
                    return;
                }
            }
        }

       
        static string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
     static void display(int x, int y, string s)
     {
         Console.SetCursorPosition(x,y);
         Console.Write(s);
     }


    }
}

