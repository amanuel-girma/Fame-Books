using FAMEBooks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.ViewModels.Book
{
    public class CreateViewModel
    {
        public Guid BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }

        [Required, DisplayName("Date Published"), DataType(DataType.Date)]
        public string DatePublished { get; set; }

        [Display(Name = "Count")]
        public int BookCount { get; set; }

        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }
        public string CreatedByUserId { get; set; }
    }
}
