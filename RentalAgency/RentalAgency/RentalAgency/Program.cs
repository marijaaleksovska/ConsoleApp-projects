using System;
using RentalAgency.Models;
namespace RentalAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            var agency = new Agency();
            Choose(agency);
        }

        private static void Choose(Agency agency)
        {
            Choices();

            Int32.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    //Create a new Rent
                    agency.CreateRent();

                    DoYouWantToContinue(agency);
                    break;
                case 2:
                    //View all rents
                    agency.ViewAllRents();
                    DoYouWantToContinue(agency);
                    break;
                case 3:
                    //View all car rents
                    agency.ViewAllCarRents();
                    DoYouWantToContinue(agency);
                    break;
                case 4:
                    //View all apartment rents
                    agency.ViewAllApartmentRents();
                    DoYouWantToContinue(agency);
                    break;
                case 5:
                    //View rent revenue
                    agency.ViewAllRevenue();
                    DoYouWantToContinue(agency);
                    break;
                case 6:
                    //View revenue from car rents
                    agency.CarRentsRevenue();
                    DoYouWantToContinue(agency);
                    break;
                case 7:
                    //View revenue from apartment rents
                    agency.ApartmentRentsRevenue();
                    DoYouWantToContinue(agency);
                    break;
                case 8:
                    // Get car rents for cars above 140 horsepowers
                    agency.CarRentWith140HorsePowersAndAbove();
                    DoYouWantToContinue(agency);
                    break;
                case 9:
                    //Get apartment rents for apartments above 100 square meters
                    agency.ApartmentRentsWith100SquareMetersAndAbove();
                    DoYouWantToContinue(agency);
                    break;
                case 10:
                    //View rent by Id
                    agency.ViewRentByID();
                    DoYouWantToContinue(agency);
                    break;
                case 11:
                    //Remove rent by id
                    agency.RemoveRentByID();
                    DoYouWantToContinue(agency);
                    break;
                case 12:
                    //View all cars and apartments available for rent
                    agency.ViewAllAvailableRents();
                    DoYouWantToContinue(agency);
                    break;
                case 13:
                    //-Add a car for rentn
                    agency.AddCarForRent();
                    DoYouWantToContinue(agency);
                    break;
                case 14:
                    //Add an apartment for rent
                    agency.AddApartmentForRent();
                    DoYouWantToContinue(agency);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    DoYouWantToContinue(agency);
                    break;
            }
        }

        private static void Choices()
        {
            Console.WriteLine("Choose:");
            Console.WriteLine(" 1-Create a new Rent");
            Console.WriteLine(" 2-View all rents");
            Console.WriteLine(" 3- View all car rents");
            Console.WriteLine(" 4-View all apartment rents");
            Console.WriteLine(" 5-View rent revenue");
            Console.WriteLine(" 6-View revenue from car rents");
            Console.WriteLine(" 7-View revenue from apartment rents");
            Console.WriteLine(" 8-Get car rents for cars above 140 horsepowers");
            Console.WriteLine(" 9-Get car rents for apartments above 100 square meters");
            Console.WriteLine(" 10-View rent by Id");
            Console.WriteLine(" 11-Remove rent by id");
            Console.WriteLine(" 12-View all cars and apartments available for rent");
            Console.WriteLine(" 13-Add a car for rent");
            Console.WriteLine(" 14-Add an apartment for rent");
        }

        private static void DoYouWantToContinue(Agency agency)
        {
            Console.WriteLine("Do you want to continue? Type y-Yes or n-No");
            if (Console.ReadLine().ToLower() == "y")
            {
                Choose(agency);
            }
            else
            {
                Console.Clear();
            }
        }
    }
}


