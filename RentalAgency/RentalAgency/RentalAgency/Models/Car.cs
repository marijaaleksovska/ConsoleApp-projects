using System;
using System.Collections.Generic;
using System.Text;

namespace RentalAgency.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int HorsePowers { get; set; }
        public string Color { get; set; }
        public void Print()
        {
            Console.WriteLine($"{ID} {Model} {HorsePowers} {Color}");
        }
    }
}
