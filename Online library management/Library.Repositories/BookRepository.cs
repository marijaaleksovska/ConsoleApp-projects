using Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        protected override string GetFileName()
        {
            return "Books.txt";
        }
    }
}
