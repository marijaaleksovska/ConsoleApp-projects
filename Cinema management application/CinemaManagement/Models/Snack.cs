using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Models
{
    public class Snack
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int OrderedQuantity { get; set; }
        public int Quantity { get; set; }
        public void Print()
        {
            Console.WriteLine($"{Name} {Price}");
        }
        public void decreaseQuantity(int input)
        {
            Quantity -= input;
        }
        public bool NotAvailable()
        {
            if (Quantity == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
