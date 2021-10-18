using System;
using Persistance;
using BL;
using System.Text;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class Menu
    {
        private static CatBL cbl = new CatBL();
        private static List<Cat> cat;
        private static InvoiceBL obl = new InvoiceBL();
        private CustomerBL customerBL = new CustomerBL();
        private static User user = new User();

        public static void MainMenu(User user)
        {

            int choice;
            string[] mainmenu = new string[] { };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                cat = cbl.GetAll();
                Console.WriteLine("                                 ┌──────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("                                 |                      ♥♥♥♥  CAT SHOP  ♥♥♥♥                        |");
                Console.WriteLine("                                 └──────────────────────────────────────────────────────────────────┘");
                Console.WriteLine("                                 ┌──────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("                                 | {0, -3}| {1, -35}| {2, -19}    |", "ID", "Name", "Price");
                Console.WriteLine("                                 └──────────────────────────────────────────────────────────────────┘");
                foreach (var list in cat)
                {
                    Console.WriteLine("                                 | {0, -3}| {1, -35}| {2, 19} VND| ", list.CatID, list.CatName, list.CatPrice.ToString("N0"));
                }
                Console.WriteLine("                                 └──────────────────────────────────────────────────────────────────┘");
                choice = tableMenu(mainmenu);
                switch (choice)
                {
                    case 1:
                        Console.Write("                                 |  Input ID: ");
                        int id;
                        try
                        {
                            if (Int32.TryParse(Console.ReadLine(), out id))
                            {
                                Cat cats = CatBL.GetCatByID(id);
                                if (cats != null)
                                {
                                    Console.Clear();
                                    Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
                                    Console.WriteLine("                         ┌──────────────────────────────────────────────────────────────────┐            ");
                                    Console.WriteLine("                         |                       ♥♥♥♥  CAT SHOP  ♥♥♥♥                       |            ");
                                    Console.WriteLine("                         └──────────────────────────────────────────────────────────────────┘            ");
                                    Console.WriteLine("                                 ┌──────────────────────────────────────────┐");
                                    Console.WriteLine("                                 |               Cat Detail                 |");
                                    Console.WriteLine("                                 └──────────────────────────────────────────┘");
                                    Console.WriteLine($"                                 |ID       : {cats.CatID}   ");
                                    Console.WriteLine($"                                 |Name     : {cats.CatName}   ");
                                    Console.WriteLine($"                                 |Age      : {cats.CatAge}     ");
                                    Console.WriteLine($"                                 |Color    : {cats.CatColor}     ");
                                    Console.WriteLine($"                                 |Weight   : {cats.CatWeight}    ");
                                    Console.WriteLine($"                                 |Longevety: {cats.CatLongevety}");
                                    Console.WriteLine($"                                 |Quantity : {cats.CatQuantity}");
                                    Console.WriteLine($"                                 |Pirce    : {cats.CatPrice.ToString("N0")} VND");
                                    Console.WriteLine("                                 └──────────────────────────────────────────┘                              ");
                                    Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
                                    Console.WriteLine("                                       Press enter to continue... ");
                                }
                                else
                                {
                                    Console.Write("                                 | ");
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write($" ID: {id} Doesn't exit!");
                                }
                            }
                            else
                            {
                                Console.Write("                                 | ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(" Invalid ID");
                            }
                            Console.ReadLine();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        catch (Exception e) { Console.WriteLine(e); }
                        break;
                    case 2:

                        Console.Write("                                 |  Input Cat Name: ");
                        string str = Console.ReadLine();
                        cat = cbl.GetByName(str);
                        ShowListCat(cat);
                        break;

                    case 3:
                        Invoice invoice = new Invoice();
                        invoice.OrderUser = user;
                        CreatInvoice(invoice);
                        break;
                    default:
                        Console.Write("                                 | ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("  Invalid choice!");
                        Console.ReadLine();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                }
                if (choice == 9)
                {
                    Console.Write("Bye Bye see you again!!!♥♥♥♥ ");
                    break;
                }
            }
        }
        static void ShowListCat(List<Cat> cats)
        {
            if (cats.Count == 0)
            {
                Console.Write("                                 | ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("  Invalid Name!!");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (cats != null)
            {
                Console.Clear();
                Console.WriteLine("                                 ┌──────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("                                 |                      ♥♥♥♥  Cat Shop  ♥♥♥♥                        |");
                Console.WriteLine("                                 └──────────────────────────────────────────────────────────────────┘");
                Console.WriteLine("                                 |                           LIST CAT                               |");
                Console.WriteLine("                                 └──────────────────────────────────────────────────────────────────┘");
                Console.WriteLine("   ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("   |{0, -3}| {1, -30}| {2, -15}| {3, -19}| {4,-10}| {5,-15}| {6, -10}|{7, -10}    |", "ID", "Name", "Age", "Color", "Weight", "Longevety", "Quantity", "Price");
                Console.WriteLine("   └──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
                Console.WriteLine("   ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
                foreach (var list in cats)
                {
                    Console.WriteLine("   |{0, -3}| {1, -30}| {2, -15}| {3, -19}| {4,-10}| {5,-15}| {6, -10}|{7, -10} VND | ", list.CatID, list.CatName, list.CatAge, list.CatColor, list.CatWeight, list.CatLongevety, list.CatQuantity, list.CatPrice.ToString("N0"));
                }
                Console.WriteLine("   └──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
                Console.WriteLine("                                                     Press enter to continue..");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static int tableMenu(string[] menu)
        {
            int choose = 0;
            int lenghtMenu = menu.Length;
            do
            {
                Console.WriteLine("                                                                                                    ▄─────────────────────────────────▄");
                Console.WriteLine("                                    Input your choice:                                              ░ Search by ID: press 1           ░");
                Console.WriteLine("                                                                                                    ░ Search By Name: press 2         ░");
                Console.WriteLine("                                                                                                    ░ Create Invoice:press 3          ░");
                Console.WriteLine("                                                                                                    ░ Exit: press 9                   ░");
                Console.WriteLine("                                                                                                    ░                                 ░");
                Console.WriteLine("                                                                                                    ░                                 ░");
                Console.WriteLine("                                                                                                    ▀─────────────────────────────────▀");
                display(55, 38);
                int.TryParse(Console.ReadLine(), out choose);
            } while (choose <= 0 && choose > lenghtMenu);
            return choose;
        }
        static void display(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }


        public static void CreatInvoice(Invoice invoice)
        {
            int id;
            int quantity;
            string str = string.Empty;
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer();
            do
            {

                Console.Write("                                   Input Cat id: ");
                int.TryParse(Console.ReadLine(), out id);
                Cat cat = CatBL.GetCatByID(id);
                if (cat == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("                                   Invalid id!!");
                    Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return;
                }
                else
                {
                    Console.Write("                                   ► Input Quantity (Max is {0}): ", cat.CatQuantity);
                    int.TryParse(Console.ReadLine(), out quantity);
                    if (quantity <= cat.CatQuantity && quantity > 0)
                    {
                        cat.CatQuantity = quantity;
                        if (cat != null && cat.CatQuantity > 0)
                        {
                            invoice.CatList.Add(cat);
                            Console.WriteLine("                                   Add successfull !!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("                                   Invalid Quantity");
                    }

                }
                Console.Write("                                   Do you want to continue ? (Y/N):");
                str = Console.ReadLine();

                switch (str.ToUpper())
                {
                    case "Y":
                    case "N":
                        break;
                    default:
                        Console.WriteLine("                                   ▲! Invalid! Please Re-enter To Continue", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                }
            } while (str.ToUpper() != "N");
            if (invoice.CatList.Count == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("                                   ► Customer Information");
                Console.Write("                                 | ");
                Console.Write(" ► Phone: ");
                invoice.OrderCustomer.CustomerPhone = Console.ReadLine();
                Console.Write("                                 | ");
                Console.Write(" ► Name: ");
                invoice.OrderCustomer.CustomerName = Console.ReadLine();
                Console.Write(" ► Address: ");
                invoice.OrderCustomer.CustomerAddress = Console.ReadLine();
                decimal totalDue = 0;
                foreach (var m in invoice.CatList)
                {
                    totalDue += m.CatPrice * m.CatQuantity;
                }
                Console.WriteLine($"                                    - TOTAL DUE: {totalDue:N0} VND");
                decimal money = 0;
                string pay;
                do
                {

                    Console.Write("                                   Do You Want To Payment(Y/N): ");
                    pay = Console.ReadLine();
                    switch (pay.ToUpper())
                    {
                        case "N":
                            Console.Clear();
                            return;
                        case "Y":
                            break;
                        default:
                            Console.WriteLine("▲ Invalid Choice", ConsoleColor.Red);
                            Console.ReadKey();
                            break;
                    }
                } while (pay.ToUpper() != "Y");

                do
                {
                    Console.Write("                                    - Enter Money: ");
                    decimal.TryParse(Console.ReadLine(), out money);
                    if (money < totalDue)
                    {
                        Console.WriteLine("                                    Invalid Money !", ConsoleColor.Red);
                        Console.ReadKey();
                    }
                } while (money < totalDue);
                decimal change = money - totalDue;
                Console.WriteLine("                                    Press Any Key To Export ...", ConsoleColor.Green);
                Console.ReadLine();
                ExportInvoice(invoice, totalDue, change, money);
            }
        }
        static void ExportInvoice(Invoice invoice, decimal totalDue, decimal change, decimal money)
        {
            decimal amount = 0;
            int totalQuantity = 0;

            string logo = @"
      ♥       █████       ██       ███████          ███████   █       █   █████    ███████       ♥ 
    /\_/\    █           █  █         █            ██         █       █  █     █  █       █    /\_/\ 
   (>'.'<)   █          █    █        █            ██         █       █  █     █  █       █   (>'.'<)
   (U   U)   █         █══════█       █            █████████  █═══════█  █     █  ████████    (U   U) 
  ('')__('') █        █        █      █                   ██  █       █  █     █  █          ('')__('')
              █████  █          █     █            ████████   █       █   █████   █
 ";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(logo);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Seller Name : Nguyễn Thành Đoàn  ");
            Console.WriteLine("Address Shop: Hà Nội");
            Console.WriteLine("Phone number: 01421234121");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"Customer Name : {invoice.OrderCustomer.CustomerName}");
            Console.WriteLine($"Customer Phone: {invoice.OrderCustomer.CustomerPhone} ");
            Console.WriteLine($"Address       : {invoice.OrderCustomer.CustomerAddress}");
            Console.WriteLine($"Date          : {invoice.OrderDate}");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│  Product                              │  Quantity   │                 price                   │");
            Console.WriteLine("│───────────────────────────────────────────────────────────────────────────────────────────────│");
            foreach (var m in invoice.CatList)
            {
                totalQuantity += m.CatQuantity;
                amount = m.CatPrice * m.CatQuantity;
                Console.WriteLine("│ {0, -35}   | {1, -10}  |  {2,35} VND|", m.CatName, m.CatQuantity, m.CatPrice.ToString("N0"));
            }
            Console.WriteLine("│───────────────────────────────────────────────────────────────────────────────────────────────│");
            Console.WriteLine($"│                        Total Quantity : {totalQuantity}           |Total Price:    {totalDue.ToString("N0"),21} VND│");
            Console.WriteLine($"│                                                     |Cash       :{money.ToString("N0"),25} VND│");
            Console.WriteLine($"│                                                     |Refunds    :{change.ToString("N0"),25} VND│");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine("           Customer                                                      Seller                  ");
            Console.WriteLine("       (Sign, fullname)                                             (Sign, fullname)  ");

            Console.ReadKey();
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void ShowHistoryTransaction(List<Invoice> invoice)
        {
            if (invoice.Count == 0)
            {

                Console.WriteLine("▲ No History !", ConsoleColor.Red);
                Console.ReadLine();
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("| No | Date Time               | Customer Name     | Customer Phone  |     Total Due (VND) |");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            // int y = 11;
            // invoice.ForEach( x =>
            // {
            //     x.CatList = CatBL.GetPriceByID(x.InvoiceID);

            // });
            foreach (var s in invoice)
            {
                Console.WriteLine($"| {s.InvoiceID,-3}| {s.OrderDate,-23} | {s.OrderCustomer.CustomerName,-17} | {s.OrderCustomer.CustomerPhone,-15} |");
            }
            Console.ReadKey();
        }
    }
}