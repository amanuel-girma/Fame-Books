using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace FAMEBooks.Models
{
    public class Book
    {
        public Book()
        {
            Loans = new List<Loan>();
        }

        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }

        [Required, DisplayName("Date Published")]
        public string DatePublished { get; set; }
        public Status Status { get; set; }
        public int BookCount { get; set; }
        public int AvailableBookCount { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Loan> Loans { get; set; }


        [ForeignKey("BookCreatedBy")]
        public string CreatedByUserId { get; set; }
        public AppUser BookCreatedBy { get; set; }

        [ForeignKey("BookUpdatedBy")]
        public string UpdatedByUserId { get; set; }
        public AppUser BookUpdatedBy { get; set; }
    }
}
