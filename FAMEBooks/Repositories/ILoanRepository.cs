using FAMEBooks.Models;
using FAMEBooks.ViewModels.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Repositories
{
    public interface ILoanRepository
    {
        public Task<List<Loan>> GetLoans();
        public Task<Loan> GetLoan(Guid id);
        public Task<List<Loan>> GetLoans(string title);
        public Task<Loan> AddAsync(Loan loan);
        public Task<Loan> UpdateAsync(Loan loan);
        public Task<Loan> DeleteAsync(Guid id);
        public Task<List<DisplayLoanRequest>> GetLoanRequests();
        Task<DisplayLoanRequest> GetLoanRequest(Guid id);
    }
}
