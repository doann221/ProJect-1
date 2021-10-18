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
            UserBL bl = new UserBL();
            User user1 = new User();
            Invoice invoice = new Invoice();
            string logo = @"
┌───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
│                                ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥♥                       │
│                                ♥          ╦        ╔═══════╗   ╔══════     ╦  ╦       ╦       ♥                       │
│                                ♥          ║        ║       ║   ║           ║  ║  \    ║       ♥                       │
│                                ♥          ║        ║       ║   ║    ══╦═   ║  ║   \   ║       ♥                       │
│                                ♥          ║        ║       ║   ║      ║    ║  ║    \  ║       ♥                       │
│                                ♥          ║    ╦   ║       ║   ║      ║    ║  ║     \ ║       ♥                       │
│                                ♥          ╩════╝   ╚═══════╝   ╚══════╝    ╩  ╩       ╩       ♥                       │
│                                ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥♥                       │";
        
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" " + dateTime);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(logo);
                Console.WriteLine("│                                  ┌─────────────────────────────┐                                                      │");
                Console.WriteLine("│                                  │ User Name:                  │                                                      │");
                Console.WriteLine("│                                  └─────────────────────────────┘                                                      │");
                Console.WriteLine("│                                  ┌─────────────────────────────┐                                                      │");
                Console.WriteLine("│                                  │ Password:                   │                                                      │");
                Console.WriteLine("│                                  └─────────────────────────────┘                                                      │");
                Console.WriteLine("│                                                                                                                       │");
                Console.WriteLine("│                                                                                                                       │");
                Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
                display(47,12);
                string userName = Console.ReadLine();
                display(46,15);
                string pass = GetPassword();
                
                Console.WriteLine();
                User user = new User() { UserName = userName, UserPassword = pass };
                user  = bl.Login(user);
                if (user == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("                     User Name or password incorrect!! Please Input again!!");
                    Console.ReadLine(); 
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Logged in successfully");
                    Console.Clear();
                    Menu.MainMenu(user1);
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
                    Console.Write("♥");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
     static void display(int x, int y)
     {
         Console.SetCursorPosition(x,y);
     }


    }
}

