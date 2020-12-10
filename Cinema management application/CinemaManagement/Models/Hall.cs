using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Models
{
    public class Hall
    {
        public int ID { get; set; }
        public int NumOfSeats { get; set; }
        public Movie MoviePlaying { get; set; }
        
        public void Print()
        {
            Console.WriteLine($"ID: {ID} MoviePlaying: {MoviePlaying.Title}");
        }
        public bool IsFull()
        {
            if (NumOfSeats == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeNumOfSeats(int input)
        {
            NumOfSeats = input;
        }
        public void ChangeNumOfSeatsAvailable(int input)
        {
            NumOfSeats -= input;
        }
        public void AddMovie(Movie movie)
        {
            MoviePlaying = movie;
        }
        public void RemoveMovie()
        {
            MoviePlaying = null;
        }
       
    }
}
