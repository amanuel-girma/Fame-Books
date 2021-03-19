using FAMEBooks.Models;
using FAMEBooks.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public BookRepository(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<Book> AddAsync(CreateViewModel book)
        {
            Book newBook = new Book
            {
                Author = book.Author,
                AvailableBookCount = book.BookCount,
                BookCount = book.BookCount,
                BookId = Guid.NewGuid(),
                CategoryId = book.CategoryId,
                DatePublished = book.DatePublished,
                CreatedByUserId = book.CreatedByUserId,
                ISBN = book.ISBN,
                Pages = book.Pages,
                Publisher = book.Publisher,
                Status = Status.Available,
                Title = book.Title,
                DateCreated = DateTime.Now.Date
            };

            context.Books.Add(newBook);
            await context.SaveChangesAsync();
            return newBook;
        }

        public async Task<Book> DeleteAsync(Guid id)
        {
            var result = await context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            context.Books.Remove(result);
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await context.Books.Include(u => u.BookUpdatedBy)
                                      .Include(b => b.BookCreatedBy)
                                      .Include(b => b.Loans)
                                      .Include(b => b.Category).FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<List<DisplayViewModel>> GetBooks()
        {
            var books = await (from b in context.Books.Include(b => b.Category)
                               select new DisplayViewModel
                               {
                                   Author = b.Author,
                                   BookId = b.BookId,
                                   BookCount = b.BookCount,
                                   CategoryId = b.CategoryId,
                                   CreatedByUserId = b.CreatedByUserId,
                                   DatePublished = b.DatePublished,
                                   ISBN = b.ISBN,
                                   Pages = b.Pages,
                                   Publisher = b.Publisher,
                                   Status = b.Status,
                                   Title = b.Title,
                                   Category = b.Category.CategoryName
                               }).ToListAsync();
            return books;
        }

        public Task<List<DisplayViewModel>> GetBooks(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> UpdateAsync(Guid id, EditViewModel updated)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.BookId == id);

            if (book != null)
            {
                book.Author = updated.Author;
                book.AvailableBookCount = updated.BookCount;
                book.BookCount = updated.BookCount;
                book.CategoryId = updated.CategoryId;
                book.DatePublished = updated.DatePublished;
                book.ISBN = updated.ISBN;
                book.Pages = updated.Pages;
                book.Publisher = updated.Publisher;
                book.Title = updated.Title;
                book.UpdatedByUserId = updated.UpdatedByUserId;

                context.Entry(book).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            return book;

        }
    }
}
