using ParkingManagement.Common.Exceptions;
using ParkingManagement.Models;
using ParkingManagement.Services;
using System;

namespace ParkingManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingService = new ParkingService();
            var continueAction = "yes";

            while (continueAction != "no")
            {

                try
                {
                    Console.WriteLine("Please choose one of the following options");
                    Console.WriteLine("1. Park");
                    Console.WriteLine("2. Leave parking");
                    Console.WriteLine("3. Buy prepaid ticket");

                    int.TryParse(Console.ReadLine(), out int userInput);

                    switch (userInput)
                    {
                        case 1:
                            parkingService.Park();
                            break;
                        case 2:
                            parkingService.Leave();
                            break;
                        case 3:
                            parkingService.BuyPrepaidTicket();
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                catch (FlowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error has occured. Please try again later.");
                }
              
                Console.WriteLine("Would you like to continue. Insert no to exit");
                continueAction = Console.ReadLine();
            }
        }
    }
}
