using System;
using CinemaManagement.Models;
namespace CinemaManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var cinemaManager = new CinemaManager();
            var input = "n";
            while (input != "y")
            {
                Console.WriteLine("Choose:");
                Console.WriteLine(" 1-Buy ticket");
                Console.WriteLine(" 2-Edit");
                Console.WriteLine(" 3-Display next playing movies");
                Console.WriteLine(" 4-Overview");
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        cinemaManager.BuyTicket();
                        break;
                    case 2:
                        Edit(cinemaManager);
                        break;
                    case 3:
                        cinemaManager.DisplayNextMoviesPlaying();
                        break;
                    case 4:
                        Overview(cinemaManager);

                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
                Console.WriteLine("Do you want to stop? Type y-Yes  of some other key");
                if (Console.ReadLine().ToLower()=="y")
                {
                    break;
                }

            }
            
        }

        private static void Overview(CinemaManager cinemaManager)
        {
            Console.WriteLine("1-Total seats sold");
            Console.WriteLine("2-Overall revenue");
            Console.WriteLine("3-Revenue from snacks");
            Console.WriteLine("4-Revenue from movie tickets only (snacks excluded)");
            Console.WriteLine("Total seats left");
            Console.WriteLine("List of all halls with movie info");
            Console.WriteLine("Info for single hall");
            Int32.TryParse(Console.ReadLine(), out int choice1);
            switch (choice1)
            {
                case 1:
                    cinemaManager.TotalSeatsSold();
                    break;
                case 2:
                    cinemaManager.TotalRevenue();
                    break;
                case 3:
                    cinemaManager.RevenueFromSnacks();
                    break;
                case 4:
                    cinemaManager.RevenueFromTickets();
                    break;
                case 5:
                    cinemaManager.SeatsLeft();
                    break;
                case 6:
                    cinemaManager.PrintHallsWithInfo();
                    break;
                case 7:
                    cinemaManager.HallInfo();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private static void Edit(CinemaManager cinemaManager)
        {
            Console.WriteLine("1-Hall");
            Console.WriteLine("2-Movie");
            Console.WriteLine("3-Snacks");
            Int32.TryParse(Console.ReadLine(), out int choice1);
            switch (choice1)
            {
                case 1:
                    //hall
                    Hall(cinemaManager);
                    break;
                case 2:
                    //movie
                    Movie(cinemaManager);
                    break;
                case 3:
                    //snack
                    Snack(cinemaManager);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private static void Snack(CinemaManager cinemaManager)
        {
            Console.WriteLine("1-Add snacks or drinks to stock");
            Console.WriteLine("2-Remove snacks or drinks from stock");
            Int32.TryParse(Console.ReadLine(), out int choice2);
            switch (choice2)
            {
                case 1:
                    cinemaManager.AddSnackToStock();
                    break;
                case 2:
                    cinemaManager.RemoveSnackFromList();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private static void Movie(CinemaManager cinemaManager)
        {
            Console.WriteLine("1-Create a new movie in the list of to be played movies");
            Console.WriteLine("2-Delete movie from the list");
            Console.WriteLine("3-Change price to a current movie");
            Int32.TryParse(Console.ReadLine(), out int choice3);
            switch (choice3)
            {
                case 1:
                    cinemaManager.CreateNewMovie();
                    break;
                case 2:
                    cinemaManager.DeleteMovie();
                    break;
                case 3:
                    cinemaManager.ChangeMoviePrice();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private static void Hall(CinemaManager cinemaManager)
        {
            Console.WriteLine("1-Create new");
            Console.WriteLine("2-Delete existing");
            Console.WriteLine("3-Change playing movie (add a new one from the list of next playing movies)");
            Console.WriteLine("4-Change the number of available seats");
            Int32.TryParse(Console.ReadLine(), out int choice2);
            switch (choice2)
            {
                case 1:
                    cinemaManager.CreateNewHall();
                    break;
                case 2:
                    cinemaManager.DeleteHall();
                    break;
                case 3:
                    cinemaManager.ChangeHallMovie();
                    break;
                case 4:
                    cinemaManager.ChangeHallNumOFSeats();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
