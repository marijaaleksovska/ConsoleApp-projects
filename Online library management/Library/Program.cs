using System;
using Library.Common;
using Library.Service;
namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose: ");
                    Console.WriteLine("1-Rent");
                    Console.WriteLine("2-Close rent");
                    Console.WriteLine("3-Manage members");
                    Console.WriteLine("4-Manage books");
                    Int32.TryParse(Console.ReadLine(), out int result);
                    switch (result)
                    {
                        case 1:
                            //rent
                            manager.Rent();
                            break;
                        case 2:
                            //close rent
                            manager.CloseRent();
                            break;
                        case 3:
                            //manage menbers
                            ManageMembers(manager);
                            break;
                        case 4:
                            //manage books
                            Console.WriteLine("Choose:");
                            Console.WriteLine("1-Show all books");
                            Console.WriteLine("2-Add new book (can not have multiple books with the same title)");
                            Console.WriteLine("3-Delete existing book");
                            Console.WriteLine("4-Print all rented books");
                            Int32.TryParse(Console.ReadLine(), out int choice1);
                            switch (choice1)
                            {
                                case 1:
                                    manager.ShowAllBooks();
                                    break;
                                case 2:
                                    manager.AddNewBook();
                                    break;
                                case 3:
                                    manager.DeleteBook();
                                    break;
                                case 4:
                                    manager.PrintRentedBooks();
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                catch(FlowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {

                    Console.WriteLine("Something went wrong.Please try again!");
                }
                Console.WriteLine("Do you want to stop?");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    break;
                }
            }
        }

        private static void ManageMembers(Manager manager)
        {
            Console.WriteLine("Choose:");
            Console.WriteLine("1-Show all members");
            Console.WriteLine("2-Create new member");
            Console.WriteLine("3-Delete existing member");
            Int32.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    manager.ShowMembers();
                    break;
                case 2:
                    manager.CreateNewMember();
                    break;
                case 3:
                    manager.DeleteMemeber();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
