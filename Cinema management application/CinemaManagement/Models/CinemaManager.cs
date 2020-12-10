using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Models
{
    public class CinemaManager
    {
        public CinemaManager()
        {
            Cinema = new Cinema();
        }
        public Cinema Cinema { get; set; }

        public void BuyTicket()
        {
            var ticket = new MovieTicket();
            var order = new Order();
            Console.WriteLine("Available Halls:");
            foreach (var hall in Cinema.Halls)
            {
                if (!hall.IsFull())
                {
                    hall.Print();
                }

            }
            Console.WriteLine("Pick the hall by typing the id of the hall.");
            int choiceHallID = int.Parse(Console.ReadLine());
            Console.Write("Number of Seats: ");
            int numSeats = int.Parse(Console.ReadLine());
            var tempHall = new Hall();
            foreach (var hall in Cinema.Halls)
            {
                if (hall.ID == choiceHallID)
                {
                    tempHall = hall;
                }
            }
            if (tempHall.NumOfSeats > numSeats)
            {
                tempHall.ChangeNumOfSeatsAvailable(numSeats);
            }
            else
            {
                Console.WriteLine("No space.");
            }
            Cinema.ChangeTotalSeatsSold(numSeats);
            ticket.Hall = tempHall;
            ticket.Movie = tempHall.MoviePlaying;
            ticket.NumOfSeats = numSeats;
            order.Ticket = ticket;
            Console.WriteLine("Dou you want any snacks or drinks? Tupe y-Yes or n-No.");
            if (Console.ReadLine().ToLower() == "y")
            {
                Cinema.Snacks.ForEach(x => x.Print());
                Console.Write("How many do you want?");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Snack{i + 1}: ");
                    string snackName = Console.ReadLine();
                    Console.Write("How many: ");
                    int x = int.Parse(Console.ReadLine());
                    var snackTemp = new Snack();
                    foreach (var snack in Cinema.Snacks)
                    {
                        if (snack.Name.ToString() == snackName)
                        {
                            snackTemp = snack;
                        }

                    }
                    if (!snackTemp.NotAvailable())
                    {
                        snackTemp.decreaseQuantity(x);
                        snackTemp.OrderedQuantity = x;

                    }
                    else
                    {
                        Console.WriteLine("Snack is not availaible");
                    }
                    order.OrderedSnacks.Add(snackTemp);
                }

            }
            Console.WriteLine("Enter your name to confirm the order:");
            string name = Console.ReadLine();
            order.CustumersName = name;
            Cinema.Orders.Add(order);


        }

        public void HallInfo()
        {
            Console.Write("Hall ID: ");
            int id = int.Parse(Console.ReadLine());
            var tempHall = new Hall();
            foreach (var hall in Cinema.Halls)
            {
                if (hall.ID == id)
                {
                    tempHall = hall;
                }
            }
            Console.WriteLine($"Hall ID:{tempHall.ID}");
            Console.WriteLine("Movie info:");
            tempHall.MoviePlaying.Print();

        }

        public void PrintHallsWithInfo()
        {
            foreach (var hall in Cinema.Halls)
            {
                Console.WriteLine($"Hall ID:{hall.ID}");
                Console.WriteLine("Movie info:");
                hall.MoviePlaying.Print();
                                            
            }
        }

        public void SeatsLeft()
        {
            Console.WriteLine($"Total seats left: {Cinema.TotalSeatsLeft()}");
        }

        public void RevenueFromTickets()
        {
            Console.WriteLine($"Revenue from Tickets: {Cinema.TicketsRevenue()}");
        }

        public void RevenueFromSnacks()
        {
            Console.WriteLine($"Revenue from snacks: {Cinema.SnacksRevenue()}");
            
        }

        public void TotalRevenue()
        {
            Console.WriteLine($"Total Revenue: {Cinema.OveralRevenue()} ");
        }

        public void TotalSeatsSold()
        {
            Console.WriteLine($"Total Seats Sold: {Cinema.TotalSeatsSold}");
        }

        public void DisplayNextMoviesPlaying()
        {
            Cinema.NextPlayingMovies.ForEach(x => Console.WriteLine(x.Title));
        }

        public void RemoveSnackFromList()
        {
            Console.Write("Sanck Name: ");
            string name = Console.ReadLine();
            var tempSnack = new Snack();
            foreach (var snack in Cinema.Snacks)
            {
                if (snack.Name == name)
                {
                    tempSnack = snack;
                }
            }
            Cinema.Snacks.Remove(tempSnack);
        }

        public void AddSnackToStock()
        {
            Console.Write("Sanck Name: ");
            string name = Console.ReadLine();
            Console.Write("Sanck Price: ");
            double p = double.Parse(Console.ReadLine());
            Console.Write("Sanck Quantity: ");
            int q = int.Parse(Console.ReadLine());
            var snack = new Snack {Name=name,Price=p,Quantity=q };
            Cinema.Snacks.Add(snack);

        }

        public void ChangeMoviePrice()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Price: ");
            double p = double.Parse(Console.ReadLine());
            var tempMovie = new Movie();
            foreach (var movie in Cinema.NextPlayingMovies)
            {
                if (movie.Title == title)
                {
                    tempMovie = movie;
                }
            }
            tempMovie.ChangePrice(p);
        }

        public void DeleteMovie()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            var tempMovie = new Movie();
            foreach (var movie in Cinema.NextPlayingMovies)
            {
                if (movie.Title == title)
                {
                    tempMovie = movie;
                }
            }
            Cinema.NextPlayingMovies.Remove(tempMovie);
        }

        public void CreateNewMovie()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Duration: ");
            double d = double.Parse(Console.ReadLine());
            Console.Write("Price: ");
            double p = double.Parse(Console.ReadLine());
            var  movie = new Movie
            {
                Title = title,
                Duration = d,
                Price = p

            };
            Console.Write("Genre: ");
            switch (Console.ReadLine().ToLower())
            {
                case "action":
                   movie.Genre= GenreEnum.Action;
                    break;
                case "drama":
                    movie.Genre = GenreEnum.Drama;
                    break;
                case "fantasy":
                    movie.Genre = GenreEnum.Fantasy;
                    break;
                case "comedy":
                    movie.Genre = GenreEnum.Comedy;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            Cinema.NextPlayingMovies.Add(movie);
            
            
        }

        public void ChangeHallNumOFSeats()
        {
            Console.Write("Hall ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Number of seats: ");
            int input = int.Parse(Console.ReadLine());
            var tempHall = new Hall();
            foreach (var hall in Cinema.Halls)
            {
                if (hall.ID == id)
                {
                    tempHall = hall;
                }
            }
            tempHall.ChangeNumOfSeats(input);
        }

        public void ChangeHallMovie()
        {
            Console.Write("Hall ID: ");
            int id = int.Parse(Console.ReadLine());
            Cinema.NextPlayingMovies.ForEach(x => Console.WriteLine($"{x.Title}"));
            Console.WriteLine("Choose Movie:");
            string movieName = Console.ReadLine();
            var tempMovie = new Movie();
            foreach (var movie in Cinema.NextPlayingMovies)
            {
                if (movie.Title == movieName)
                {
                    tempMovie = movie;
                }
            }
            var tempHall = new Hall();
            foreach (var hall in Cinema.Halls)
            {
                if (hall.ID == id)
                {
                    tempHall = hall;
                }
            }
            tempHall.AddMovie(tempMovie);
        }

        public void DeleteHall()
        {
            Console.Write("Hall ID: ");
            int id = int.Parse(Console.ReadLine());
            var tempHall = new Hall();
            foreach (var hall in Cinema.Halls)
            {
                if (hall.ID == id)
                {
                    tempHall = hall;
                }

            }
            Cinema.Halls.Remove(tempHall);
        }

        public void CreateNewHall()
        {
            Console.Write("Hall ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Number of Seats: ");
            int num = int.Parse(Console.ReadLine());
            var hall = new Hall
            {
                ID = id,
                NumOfSeats=num
            };
            if (Cinema.Halls.Count < 5)
            {
                Cinema.Halls.Add(hall);
            }
            else
            {
                Console.WriteLine("Error:You have already 5 halls");
            }
        }
    }
}
