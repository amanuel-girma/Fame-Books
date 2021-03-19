using FAMEBooks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.ViewModels.Loan
{
    public class CreateViewModel
    {
        [Required]
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string DatePublished { get; set; }
        public int Pages { get; set; }
    }
}
