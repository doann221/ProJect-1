using System;
using Persistance;
using BL;
using System.Text;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class Menu
    {
        public static void MainMenu()
        {
            int choice, chosse;
            CatBL cbl = new CatBL();
            List<Cat> cat;
            OrderBL obl = new OrderBL();
            string title = "";
            string[] mainmenu = new string[] { "Search", "Create Invoice", "Exit" };
            string[] searchMenu = new string[] { "Search By ID ", " Search By Name  ", " Back to menu " };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                cat = cbl.GetAll();
                Console.WriteLine("────────────────────────────────────────────────────────────────────");
                Console.WriteLine("|                      ♥♥♥♥  Cat Shop  ♥♥♥♥                        |");
                Console.WriteLine("────────────────────────────────────────────────────────────────────");
                Console.WriteLine("────────────────────────────────────────────────────────────────");
                Console.WriteLine("| {0, -3}| {1, -35}| {2, -19}|", "ID", "Name", "Price");
                Console.WriteLine("────────────────────────────────────────────────────────────────");
                foreach (var list in cat)
                {
                    Console.WriteLine("| {0, -3}| {1, -35}| {2, 15} VND| ", list.CatID, list.CatName, list.CatPrice);
                }
                Console.WriteLine("────────────────────────────────────────────────────────────────");
                choice = tableMenu(title, mainmenu);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("────────────────────────────────────────────────────────────────────");
                            Console.WriteLine("|                      ♥♥♥♥  Cat Shop  ♥♥♥♥                        |");
                            Console.WriteLine("────────────────────────────────────────────────────────────────────");
                            chosse = tableMenu("|\t\t Search \t\t |", searchMenu);

                            switch (chosse)
                            {
                                case 1:
                                    Console.Write("Input ID: ");
                                    int id;
                                    try
                                    {
                                        if (Int32.TryParse(Console.ReadLine(), out id))
                                        {
                                            Cat cats = CatBL.GetCatByID(id);

                                            if (cats != null)
                                            {
                                                Console.WriteLine("────────────────────────────────────────────────────────────────────");
                                                Console.WriteLine("|                      ♥♥♥♥  Cat Shop  ♥♥♥♥                        |");
                                                Console.WriteLine("────────────────────────────────────────────────────────────────────");
                                                Console.WriteLine("         ────────────────────────────────────────────");
                                                Console.WriteLine("         |               Cat Detail                 |");
                                                Console.WriteLine("         ────────────────────────────────────────────");
                                                Console.WriteLine($"         |ID       :{cats.CatID} ");
                                                Console.WriteLine($"         |Name     :{cats.CatName}");
                                                Console.WriteLine($"         |Age      :{cats.CatAge}");
                                                Console.WriteLine($"         |Color    :{cats.CatColor}");
                                                Console.WriteLine($"         |Weight   :{cats.CatWeight}");
                                                Console.WriteLine($"         |Longevety:{cats.CatLongevety}");
                                                Console.WriteLine($"         |Quantity :{cats.CatQuantity}");
                                                Console.WriteLine($"         |Pirce    :{cats.CatPrice} VND");
                                                Console.WriteLine("          ────────────────────────────────────────────");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"ID: {id} Doesn't exit!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid id");
                                        }
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    catch (Exception e) { Console.WriteLine(e); }
                                    break;
                                case 2:
                                    Console.Write("Input Cat Name: ");
                                    string str = Console.ReadLine();
                                    cat = cbl.GetByName(str);
                                    ShowListCat(cat);
                                    break;
                                case 3:
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice!");
                                    break;
                            }
                        } while (chosse != 3);
                        break;
                    case 2:
                        Order order = new Order();

                        Console.Write("Input ID: ");
                        int id1;
                        try
                        {
                            if (Int32.TryParse(Console.ReadLine(), out id1))
                            {
                                Cat cats = CatBL.GetCatByID(id1);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Create Order: " + (obl.CreateOrder(order) ? " completed!" : "Create Complete"));

                                Console.WriteLine("Press any key to continue");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        catch (Exception e) { Console.WriteLine(e); }
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Invalid chhoice!");
                        break;
                }
                if (choice == 3) { break; }
            }
        }
        static void ShowListCat(List<Cat> cats)
        {
            if (cats.Count == 0)
            {
                Console.WriteLine("this name doesn't exit in the system!");
                Console.ReadLine();
            }
            else if (cats != null)
            {
                Console.WriteLine("────────────────────────────────────────────────────────────────────");
                Console.WriteLine("|                      ♥♥♥♥  Cat Shop  ♥♥♥♥                        |");
                Console.WriteLine("────────────────────────────────────────────────────────────────────");
                Console.WriteLine("────────────────────────────────────────────────────────────────");
                Console.WriteLine("| {0, -3}| {1, -35}| {2, -19}|", "ID", "Name", "Price");
                Console.WriteLine("────────────────────────────────────────────────────────────────");
                foreach (var list in cats)
                {
                    Console.WriteLine("| {0, -3}| {1, -35}| {2, 15} VND| ", list.CatID, list.CatName, list.CatPrice);
                }
                Console.WriteLine("────────────────────────────────────────────────────────────────");
                Console.WriteLine("Press enter to continue..");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static int tableMenu(string title, string[] menu)
        {
            int choose = 0;
            int lenghtMenu = menu.Length;

            Console.WriteLine(title);
            Console.WriteLine("──────────────────────────────────────────");
            for (int i = 0; i < lenghtMenu; i++)
            {
                Console.WriteLine($"|{i + 1} . {menu[i]} ");
            }
            Console.WriteLine("──────────────────────────────────────────");
            do
            {
                Console.Write("choose: ");
                int.TryParse(Console.ReadLine(), out choose);
            } while (choose <= 0 && choose > lenghtMenu);
            return choose;
        }
    }
}
