using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Models
{
    public class Category
    {
        public Category()
        {
            Books = new List<Book>();
        }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Book> Books { get; set; }
    }
}
