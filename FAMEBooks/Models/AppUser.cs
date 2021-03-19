using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            BookLendBy = new List<Loan>();
            BookBorrowedBy = new List<Loan>();
        }

        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        
        [Required, DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [InverseProperty(nameof(BookLendBy))]
        public List<Loan> BookLendBy { get; set; }

        [InverseProperty(nameof(BookBorrowedBy))]
        public List<Loan> BookBorrowedBy { get; set; }

        [InverseProperty(nameof(BookCreatedBy))]
        public List<Book> BookCreatedBy { get; set; }

        [InverseProperty(nameof(BookUpdatedBy))]
        public List<Book> BookUpdatedBy { get; set; }
    }
}
