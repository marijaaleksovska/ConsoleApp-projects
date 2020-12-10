using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Models
{
    public class Order
    {
        public MovieTicket Ticket { get; set; }
        public string CustumersName { get; set; }
        public List<Snack> OrderedSnacks { get; set; } = new List<Snack>();
        public double FullPrice()
        {
            double sum = 0.0;
            foreach (var snack in OrderedSnacks)
            {
                sum += snack.Price;
            }
            return sum+Ticket.Movie.Price;
        }
        public double PriceFromSnacks()
        {
            double sum = 0.0;
            foreach (var snack in OrderedSnacks)
            {
                sum += snack.Price*snack.OrderedQuantity;
            }
            return sum;
        }
    }
}
