using System;
using System.Collections.Generic;
using System.Text;

namespace RentalAgency.Models
{
    public class Apartment
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public int SquareMeters { get; set; }
        public int NumberOfRooms { get; set; }
        public void Print()
        {
            Console.WriteLine($"{ID} {Address} {SquareMeters} {NumberOfRooms}");
        }
    }
}
