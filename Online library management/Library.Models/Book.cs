using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class Book
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumOfCopies { get; set; }
        
        public void Print()
        {
            Console.WriteLine($"{Id} {Title}");
        }
        public void DecreaseNumOfCopies()
        {
            NumOfCopies --;
        }
        public void IncreaseNumOfCopies()
        {
            NumOfCopies ++;
        }

    }
}

