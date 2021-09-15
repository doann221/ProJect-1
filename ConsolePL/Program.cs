using System;
using Persistance;
using BL;

namespace ConsoleAppPL
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            string[] menu1 = new string[3] {"|1. Search                           |", "|2. CreateInvoice                    |", "|3. Exit                             |" };
            string[] menu2 = new string[2] {"|1. Search by name                   | ","|2. Search by id                     |"};
            Console.WriteLine();
            UserBL bl = new UserBL();
            while (true)
        {  
            Console.ForegroundColor= ConsoleColor.DarkGreen;
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
            string str ;
            if (login <= 0)
            {
            Console.WriteLine("User Name or password incorrect!! Please Input again!!");
            Console.Write("Do you want to continue? (Y/N): ");
            str = Console.ReadLine();
            if(str != "y" || str != "Y"){
                if(str != "n" || str != "n"){
                   Console.WriteLine("INVALID CHOICE");
                   
                }
            }
            switch (str)
            {
                case "Y":
                    break;
                case "y":
                    break;
                    case "N": return;
                    case "n": return;
            }
         }
            else
            {
            Console.WriteLine("Logged in successfully");
            Console.Clear();
        do{
                Console.ForegroundColor= ConsoleColor.DarkCyan;
                Menu(menu1);
                Console.Write("Your choice: ");
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 3)
                {
                Console.WriteLine("Your chocie wrong !! Please choice again!!");
                Console.ReadLine();
                }
            switch(choice)
            {
                case 1: 
                    Menu(menu2);
                    SearchMenu();
                    break;
                case 2: 
                Console.WriteLine("Hello");
                break;
                case 3: 
                break;
            }
                break;
        }while(choice < 1 || choice > 3);
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
    static void SearchMenu(){ 
        int str=0;
        do{
           Console.Write("Input your choice: ");
                str = int.Parse(Console.ReadLine());
                if (str < 1 || str > 2)
                {
                Console.Write("Your chocie wrong !! Please choice again!!");
                Console.ReadLine();
                }
                switch (str)
                {
                    case 1: 
                   SearchByName();
                    break;
                    case 2:
                   SearchByID();
                    break;
                }
            }while(str <1 || str > 2);
                
    }
    public static void SearchByID(){
            bool stop = false;
            int choice =  -1;
            
            while(!stop)
            {
                Console.Clear();
                Console.WriteLine("+--------------------------+");
                Console.WriteLine("|       Search By ID       |");
                Console.WriteLine("+--------------------------+");
                Console.Write("Input ID : ");
                string input = Console.ReadLine();
                if(!int.TryParse(input, out choice)) choice = -1;
                if(choice == 0)
                {
                    stop = true;
                    break;
                }
                while(choice < 1)
                {
                    Console.Write("Invalid!choice again : ");
                    input = Console.ReadLine();
                    if(!int.TryParse(input,out choice)) choice = -1;
                }
                Cat cat = new Cat();
                CatBL cbl = new CatBL();
                cat = cbl.SearchCatByID(choice);
                Console.WriteLine(cat);
                Console.Write("Do you want to continue? (Y/N): ");
                string str = Console.ReadLine();
                if(input == "y"|| input == "Y"){
                    continue;
                }
                if(input == "n"|| input == "N"){
                    break;
                }
               break;
            }
        }
        public static void SearchByName()
        {
            bool stop = false;
            int choice =  -1;
            
            while(!stop)
            {
                Console.Clear();
                Console.WriteLine("+--------------------------+");
                Console.WriteLine("|       Search By Name     |");
                Console.WriteLine("+--------------------------+");
                Console.Write("Input Name : ");
                string input = Console.ReadLine();
                if(!int.TryParse(input, out choice)) choice = -1;
                if(choice == 0){
                    stop = true;
                    break;
                }
                while(choice < 1){
                    Console.Write("Invalid!choice again : ");
                    input = Console.ReadLine();
                    if(!int.TryParse(input,out choice)) choice = -1;
                }
                Cat cat = new Cat();
                CatBL cbl = new CatBL();
                cat = cbl.SearchCatByName(choice);
                Console.WriteLine(cat);
                Console.ReadLine();
            }
    }
}
}
