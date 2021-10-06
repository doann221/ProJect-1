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
            int choice = 0;
            string[] menu1 = new string[3] { "|1. Search                           |", "|2. CreateInvoice                    |", "|3. Exit                             |" };
            string[] menu2 = new string[3] { "|1. Search by name                   | ", "|2. Search by id                     |", "|3. Exit                             |" };
            Console.WriteLine();
            UserBL bl = new UserBL();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(" " + dateTime);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                GetLine();
                Console.WriteLine("+--        Login                   --+");
                GetLine();
                Console.Write("User Name: ");
                string userName = Console.ReadLine();
                Console.Write("Password: ");
                string pass = GetPassword();
                Console.WriteLine();
                GetLine();
                User user = new User() { UserName = userName, UserPassword = pass };
                int login = bl.Login(user);
                string str;
                if (login <= 0)
                {
                    Console.WriteLine("User Name or password incorrect!! Please Input again!!");
                    Console.Write("Do you want to continue? (Y/N): ");
                    str = Console.ReadLine();
                    if (str != "y" || str != "Y")
                    {
                        if (str != "n" || str != "n")
                        {
                            Console.WriteLine("INVALID CHOICE");

                        }
                    }
                    switch (str)
                    {
                        case "Y": break;
                        case "y": break;
                        case "N": return;
                        case "n": return;
                    }
                }
                else
                {
                    Console.WriteLine("Logged in successfully");
                    Console.Clear();
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Menu(menu1);
                        Console.Write("Your choice: ");
                        choice = int.Parse(Console.ReadLine());
                        if (choice < 1 || choice > 3)
                        {
                            Console.WriteLine("Your chocie wrong !! Please choice again!!");
                            Console.ReadLine();
                        }
                        switch (choice)
                        {
                            case 1:
                                Menu(menu2);
                                int str1 = 0;
                                CatBL cbl = new CatBL();

                                do
                                {
                                    Console.Write("Input your choice: ");
                                    str1 = int.Parse(Console.ReadLine());
                                    if (str1 < 1 || str1 > 3)
                                    {
                                        Console.Write("Your chocie wrong !! Please choice again!!");
                                        Console.ReadLine();
                                    }
                                    switch (str1)
                                    {
                                        case 1:
                                            Console.WriteLine("Input Name: ");
                                            string str2 = Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.Write("Input ID : ");
                                            int input;
                                            if (Int32.TryParse(Console.ReadLine(), out input))
                                            {
                                                Cat cat = cbl.GetCatByID(input);
                                                if (cat != null)
                                                {
                                                    Console.WriteLine(cat.CatID);
                                                    Console.WriteLine(cat.CatName);
                                                    Console.WriteLine(cat.CatPrice);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("no info");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("invalid");
                                            }
                                            break;
                                        case 3:
                                            break;
                                    }
                                } while (str1 < 1 || str1 > 3);
                                break;
                            case 2:
                                Console.WriteLine("Hello");
                                break;
                            case 3:
                                break;
                        }
                        break;
                    } while (choice < 1 || choice > 3);
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
        static void GetLine()
        {
            Console.WriteLine("+====================================+");
        }
        static void GetLine1()
        {
            Console.WriteLine("+===========================================================+");
        }
        static void Menu(string[] menu)
        {
            int lenghtMenu = menu.Length;

            GetLine();
            Console.WriteLine("+--        Cat Sale                --+");
            GetLine();
            for (int i = 0; i < lenghtMenu; i++)
            {
                Console.WriteLine(menu[i]);
            }
            GetLine();
        }
        private static short Menu(string title, string[] menuItems)
        {
            string logo = @"==============================================
╔╦╗┬ ┬┬─┐┌─┐┌─┐  ╦  ┌─┐┬ ┬┌─┐┬─┐  ╔╦╗┌─┐┌┬┐┌─┐
 ║ ├─┤├┬┘├┤ ├┤   ║  ├─┤└┬┘├┤ ├┬┘   ║║├┤ ││││ │
 ╩ ┴ ┴┴└─└─┘└─┘  ╩═╝┴ ┴ ┴ └─┘┴└─  ═╩╝└─┘┴ ┴└─┘";
            short choose = 0;
            Console.WriteLine(logo);
            string line = "==============================================";
            Console.WriteLine(line);
            Console.WriteLine(" " + title);
            Console.WriteLine(line);
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + menuItems[i]);
            }
            Console.WriteLine(line);
            do
            {
                Console.Write("Your choice: ");
                try
                {
                    choose = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Your Choose is wrong!");
                    continue;
                }
            } while (choose <= 0 || choose > menuItems.Length);
            return choose;
        }
        // static void SearchMenu(){ 
        //     int str=0;
        //     CatBL cbl = new CatBL();

        //     do{
        //        Console.Write("Input your choice: ");
        //             str = int.Parse(Console.ReadLine());
        //             if (str < 1 || str > 3)
        //             {
        //             Console.Write("Your chocie wrong !! Please choice again!!");
        //             Console.ReadLine();
        //             }
        //             switch (str)
        //             {
        //                 case 1: 
        //                     Console.WriteLine("Input Name: ");
        //                     string str1 = Console.ReadLine();
        //                 break;
        //                 case 2:
        //                 Console.Write("Input ID : ");
        //             int input;
        //                if(int.TryParse(Console.ReadLine(), out input)){
        //               Cat cat =  cbl.SearchCatByID(input);
        //               if(cat != null){
        //                   Console.WriteLine(cat.CatID);
        //                   Console.WriteLine(cat.CatName);
        //                   Console.WriteLine(cat.CatPrice);
        //               }else
        //               {
        //                  Console.WriteLine("no info"); 
        //               }
        //             }else{
        //                 Console.WriteLine("invalid");
        //             }
        //                 break;
        //                 case 3:
        //                 break;
        //             }
        //         }while(str <1 || str > 3);

        // }
        // public static void SearchByID(CatBL cbl){
        //         bool stop = false;
        //        // int choice =  -1;


        //         while(!stop)
        //         {
        //             Console.Clear();
        //             GetLine1();
        //             Console.WriteLine("|                           CAT SALE                        |");
        //             GetLine1();
        //             Console.WriteLine("|                       Search By ID                        |");
        //             GetLine1();
        //             Console.Write("Input ID : ");
        //             int input;
        // if(!int.TryParse(input, out choice)) choice = -1;
        // if(choice == 0)
        // {
        //     stop = true;
        //     break;
        // }
        // while(choice < 1)
        // {
        //     Console.Write("Invalid!choice again : ");
        //     input = Console.ReadLine();
        //     if(!int.TryParse(input,out choice)) choice = -1;
        // }

        // cat = cbl.SearchCatByID(choice);
        // Console.WriteLine(cat);
        // Console.Write("Do you want to continue?(Y/N) :");
        // string str = Console.ReadLine();
        //  if (str == "N" || str == "n")
        //  {
        //     break;
        //  }
        //  else if (str == "Y" || str == "y")
        //  {
        //      continue;
        //  }
        //         if(int.TryParse(Console.ReadLine(), out input)){
        //           Cat cat =  cbl.SearchCatByID(input);
        //           if(cat != null){
        //               Console.WriteLine(cat.CatID);
        //               Console.WriteLine(cat.CatName);
        //               Console.WriteLine(cat.CatPrice);
        //           }else
        //           {
        //              Console.WriteLine("no info"); 
        //           }
        //         }else{
        //             Console.WriteLine("invalid");
        //         }

        //     }
        // }
        // public static void SearchByName()
        // {
        //     bool stop = false;
        //     int choice =  -1;

        //     while(!stop)
        //     {
        //         Console.Clear();
        //        GetLine1();
        //         Console.WriteLine("|                           CAT SALE                        |");
        //          GetLine1();
        //         Console.WriteLine("|                       Search By Name                      |");
        //         GetLine1();
        //         Console.Write("Input Name : ");
        //         string input = Console.ReadLine();
        //         if(!int.TryParse(input, out choice)) choice = -1;
        //         if(choice == 0){
        //             stop = true;
        //             break;
        //         }
        //         // while(choice < 1){
        //             Console.Write("Invalid!choice again : ");
        //             input = Console.ReadLine();
        //             if(!int.TryParse(input,out choice)) choice = -1;
        //         //}
        //         Cat cat = new Cat();
        //         CatBL cbl = new CatBL();
        //         cat = cbl.SearchCatByName(choice);
        //         Console.WriteLine(cat);
        //         Console.ReadLine();
        //     }
    }
}

