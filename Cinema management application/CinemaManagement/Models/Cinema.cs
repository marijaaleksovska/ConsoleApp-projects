using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Models
{
    public class Cinema
    {
        
        public List<Hall> Halls { get; set; } = new List<Hall>(5);
        public List<Movie> NextPlayingMovies { get; set; } = new List<Movie>(10);
        public List<Snack> Snacks { get; set; } = new List<Snack>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public int TotalSeatsSold { get; set; }
        public void ChangeTotalSeatsSold(int i)
        {
            TotalSeatsSold += i;
        }
        public double OveralRevenue()
        {
            double sum = 0.0;
            foreach (var order in Orders)
            {
                sum += order.FullPrice();

            }
            return sum;
        }
        public double SnacksRevenue()
        {
            double sum = 0.0;
            foreach (var order in Orders)
            {
                sum += order.PriceFromSnacks();

            }
            return sum;
        }
        public double TicketsRevenue()
        {
            double sum = 0.0;
            foreach (var order in Orders)
            {
                sum += order.Ticket.Movie.Price;

            }
            return sum;
        }
        public int TotalSeatsLeft()
        {
            int seats=0;
            foreach (var hall in Halls)
            {
                seats += hall.NumOfSeats;
            }
            return seats;
        }

    }
}
