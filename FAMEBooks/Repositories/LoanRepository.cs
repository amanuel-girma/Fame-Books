using FAMEBooks.Models;
using FAMEBooks.ViewModels.Loan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext context;

        public LoanRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Loan> AddAsync(Loan loan)
        {
            await context.Loans.AddAsync(loan);
            await context.SaveChangesAsync();
            return loan;
        }
        public Task<List<Loan>> GetLoans(string title)
        {
            throw new NotImplementedException();
        }
        public async Task<Loan> GetLoan(Guid id)
        {
            return await context.Loans.FirstOrDefaultAsync(l => l.Id == id);
        }
        public Task<List<Loan>> GetLoans()
        {
            throw new NotImplementedException();
        }
        public async Task<Loan> UpdateAsync(Loan loan)
        {
            var result = await context.Loans.FirstOrDefaultAsync(l => l.Id == loan.Id);
            context.Entry<Loan>(result).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return result;
        }
        public Task<Loan> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<DisplayLoanRequest>> GetLoanRequests()
        {
            var result = from book in context.Books
                         join loan in context.Loans
                                            .Include(l => l.BookBorrowedBy)
                                            .Include(l => l.BookLendBy) on book.BookId equals loan.BookId
                         select new DisplayLoanRequest
                         {
                             BookId = book.BookId,
                             LoanId = loan.Id,
                             Author = book.Author,
                             Borrower = loan.BookBorrowedBy != null ? loan.BookBorrowedBy.FirstName + " " + loan.BookBorrowedBy.LastName : "",
                             Title = book.Title,
                             Status = loan.BorrowStatus.ToString()
                         };
            return await result.ToListAsync();
        }

        public async Task<DisplayLoanRequest> GetLoanRequest(Guid id)
        {
            var result = from book in context.Books
                         join loan in context.Loans
                                            .Include(l => l.BookBorrowedBy)
                                            .Include(l => l.BookLendBy) on book.BookId equals loan.BookId
                         select new DisplayLoanRequest
                         {
                             BookId = book.BookId,
                             LoanId = loan.Id,
                             Author = book.Author,
                             Borrower = loan.BookBorrowedBy != null ? loan.BookBorrowedBy.FirstName + " " + loan.BookBorrowedBy.LastName : "",
                             Title = book.Title,
                             Status = loan.BorrowStatus.ToString()
                         };
            return await result.FirstOrDefaultAsync(l => l.LoanId == id);
        }
    }
}