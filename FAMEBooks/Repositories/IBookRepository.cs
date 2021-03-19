using FAMEBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using FAMEBooks.ViewModels.Book;
using System.Threading.Tasks;

namespace FAMEBooks.Repositories
{
    public interface IBookRepository
    {
        public Task<List<DisplayViewModel>> GetBooks();
        public Task<Book> GetBook(Guid id);
        public Task<List<DisplayViewModel>> GetBooks(string title);
        public Task<Book> AddAsync(CreateViewModel book);
        public Task<Book> UpdateAsync(Guid id, EditViewModel book);
        public Task<Book> DeleteAsync(Guid id);
    }
}
