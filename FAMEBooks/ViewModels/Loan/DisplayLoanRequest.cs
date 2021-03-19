using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.ViewModels.Loan
{
    public class DisplayLoanRequest
    {
        public Guid BookId { get; set; }
        public Guid LoanId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Borrower { get; set; }
        public string LendBy { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
