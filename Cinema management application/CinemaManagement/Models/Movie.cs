using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public double Duration { get; set; }
        public GenreEnum Genre { get; set; }
        public double Price { get; set; }
        public void ChangePrice(double input)
        {
            Price = input;
        }
        public void Print()
        {
            Console.WriteLine($"{Title} {Duration} {Genre} {Price}");
        }
    }
}
