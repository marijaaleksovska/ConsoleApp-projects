using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class Member
    {
        public Member()
        {
            RentedBooks = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<Book> RentedBooks { get; set; }
        public void PrintMember()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"{Id} {Name} {Surname} {Email}");
            
            if (RentedBooks.Count == 0)
            {
                Console.WriteLine($"Rented books: none");
            }
            else
            {
                Console.WriteLine($"Rented books:");
                RentedBooks.ForEach(x => x.Print());
            }
            
        }
        public void ShowRentedBooks()
        {

            RentedBooks.ForEach(x => Console.WriteLine($"Rented Book: {x.Id} {x.Title} Rented By: {Name} {Surname}"));
        }
    }
}

