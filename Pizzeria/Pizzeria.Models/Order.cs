using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Models
{
    public class Order
    {
        public Order()
        {
            Toppings = new List<string>();
            IsCompleate = false;
        }
        public Pizza Pizza { get; set; }
        public List<string> Toppings { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsCompleate { get; set; }
        public void Print()
        {
            Console.WriteLine($"Pizza: {Pizza.Type} {Pizza.Size}");
            Console.WriteLine($"Toppings: {string.Join(',',Toppings)}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");

        }
    }
}
