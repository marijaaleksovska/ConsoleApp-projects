using Library.Common;
using Library.Models;
using Library.Repositories;
using System;
using System.Linq;


namespace Library.Service
{
    public class Manager
    {
        public Manager()
        {
            BookRepository = new BookRepository();
            MemberRepository = new MemberRepository();
        }
        public BookRepository BookRepository { get; set; }
        public MemberRepository MemberRepository { get; set; }
        public void Rent()
        {
            Console.Write("Member Id:");
            int memberId = int.Parse(Console.ReadLine());
            if (MemberRepository.GetFirstWhere(x => x.Id == memberId) == null)
            {
                throw new FlowException("You are not a member in this library!");
            }
            if(MemberRepository.GetFirstWhere(x => x.Id == memberId).RentedBooks.Count == 3)
            {
                throw new FlowException("You have already rented 3 books.You cant rent more!");
            }
            var member = MemberRepository.GetFirstWhere(x => x.Id == memberId);
            Console.WriteLine("Available books for rent: *choose by ID of the book");
            var availableBooks = BookRepository.GetAllWhere(x => x.NumOfCopies > 0);
            availableBooks.ForEach(x => x.Print());
            int bookID = int.Parse(Console.ReadLine());
            if (BookRepository.GetFirstWhere(x => x.Id == bookID) == null)
            {
                throw new FlowException("Book with this id does not exist");
            }
            if (member.RentedBooks.FirstOrDefault(x => x.Id == bookID) != null)
            {
                throw new FlowException("You have already rented thid book.");
            }
            var book = BookRepository.GetFirstWhere(x => x.Id == bookID);
            book.DecreaseNumOfCopies();
          
            member.RentedBooks.Add(book);
            BookRepository.SaveChanges();
            MemberRepository.SaveChanges();
        }

        public void ShowAllBooks()
        {
            BookRepository.GetAll().ForEach(x => x.Print());
        }

        public void CreateNewMember()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            if (MemberRepository.GetFirstWhere(x => x.Email == email) != null)
            {
                throw new FlowException("Already exist member with this email!Try again.");
            }
            int memberId = GemerateMemberID();
            var newMember = new Member();
            newMember.Id = memberId;
            newMember.Name = name;
            newMember.Surname = surname;
            newMember.Email = email;
            MemberRepository.Add(newMember);
            MemberRepository.SaveChanges();


        }

        public void PrintRentedBooks()
        {
            MemberRepository.GetAllWhere(x => x.RentedBooks.Count > 0).ForEach(x => x.ShowRentedBooks());
        }

        public void DeleteBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            if(BookRepository.GetFirstWhere(x => x.Title == title) == null)
            {
                throw new FlowException("This book does not exists.");
            }
            var allMembers=MemberRepository.GetAll();
            var rentedBooks = allMembers.Where(x => x.RentedBooks.Count > 0).ToList().SelectMany(x => x.RentedBooks).ToList();
            if (rentedBooks.FirstOrDefault(x => x.Title == title) != null)
            {
                throw new FlowException("This book is rented by someone,you cant delete it");
            }
            var book = BookRepository.GetFirstWhere(x => x.Title == title);
            BookRepository.Remove(book);
            BookRepository.SaveChanges();


        }

        public void AddNewBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            if (BookRepository.GetFirstWhere(x => x.Title == title)!=null)
            {
                throw new FlowException("This book exists.");
            }
            Console.Write("Number of Copies: ");
            int numOfCopies = int.Parse(Console.ReadLine());
            int bookId = GemerateBookID();
            var newBook = new Book();
            newBook.Id = bookId;
            newBook.Title = title;
            newBook.NumOfCopies = numOfCopies;
            BookRepository.Add(newBook);
            BookRepository.SaveChanges();
        }
        private int GemerateBookID()
        {
            var allBooks = BookRepository.GetAll();

            var maxId = 0;

            if (allBooks.Any())
            {
                maxId = allBooks.Max(x => x.Id);
            }

            maxId += 1;
            return maxId;
        }
        public void DeleteMemeber()
        {
            Console.Write("Member`s id: ");
            int memberId = int.Parse(Console.ReadLine());
            if (MemberRepository.GetFirstWhere(x => x.Id == memberId) == null)
            {
                throw new FlowException("This member does not exist.");
            }
            if(MemberRepository.GetFirstWhere(x => x.Id == memberId).RentedBooks.Count > 0)
            {
                throw new FlowException("You have rented book/s.");
            }
            var member = MemberRepository.GetFirstWhere(x => x.Id == memberId);
            MemberRepository.Remove(member);
            MemberRepository.SaveChanges();

        }

        private int GemerateMemberID()
        {
            var allMembers = MemberRepository.GetAll();

            var maxId = 0;

            if (allMembers.Any())
            {
                maxId = allMembers.Max(x => x.Id);
            }

            maxId += 1;
            return maxId;
        }

        public void ShowMembers()
        {
            MemberRepository.GetAll().ForEach(x => x.PrintMember());
        }

        public void CloseRent()
        {
            Console.Write("Member Id:");
            int memberId = int.Parse(Console.ReadLine());
            if (MemberRepository.GetFirstWhere(x => x.Id == memberId) == null)
            {
                throw new FlowException("You are not a member in this library!");
            }
            
            var member = MemberRepository.GetFirstWhere(x => x.Id == memberId);
            Console.WriteLine("Rented books:");
            member.RentedBooks.ForEach(x => x.Print());
            Console.WriteLine("Choose by the id of the book you want to return.");

            int bookID = int.Parse(Console.ReadLine());
            if (BookRepository.GetFirstWhere(x => x.Id == bookID) == null)
            {
                throw new FlowException("Book with this id does not exist");
            }

            
            if (member.RentedBooks.FirstOrDefault(x => x.Id == bookID) == null)
            {
                throw new FlowException("You have not rented this book");
            }
            var book = member.RentedBooks.FirstOrDefault(x => x.Id == bookID);
            member.RentedBooks.Remove(book);
            BookRepository.GetFirstWhere(x => x.Id == bookID).IncreaseNumOfCopies();

            BookRepository.SaveChanges();
            MemberRepository.SaveChanges();

        }
    }
}
