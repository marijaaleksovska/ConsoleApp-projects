using System;
using Pizzeria.Managment;
namespace Pizzeria
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
                    Console.WriteLine("Choose:");
                    Console.WriteLine(" 1-Create order");
                    Console.WriteLine(" 2-Mark order as complete");
                    Console.WriteLine(" 3-Manage pizza");
                    Console.WriteLine(" 4-Manage delivery guys");
                    Int32.TryParse(Console.ReadLine(), out int result);
                    switch (result)
                    {
                        case 1:
                            //order
                            break;
                        case 2:
                            //order complete
                            break;
                        case 3:
                            //pizza
                            break;
                        case 4:
                            //delivery guys
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }

                }

                catch (Exception ex)
                {

                    Console.WriteLine("Something went wrong.Please try again!");
                }
                Console.WriteLine("Do you want to stop? ");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    break;
                }
            }
        }
    }
}
