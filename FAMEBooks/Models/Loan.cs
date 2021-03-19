using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Models
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Status BorrowStatus { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? BorrowEndDate { get; set; }
        public DateTime? DateReturned { get; set; }
        public bool IsReturned { get; set; }

        [ForeignKey("BookLendBy")]
        public string LendByUserId { get; set; }
        public AppUser BookLendBy { get; set; }

        [ForeignKey("BookBorrowedBy")]
        public string BorrowedByUserId { get; set; }
        public AppUser BookBorrowedBy { get; set; }
    }
}
