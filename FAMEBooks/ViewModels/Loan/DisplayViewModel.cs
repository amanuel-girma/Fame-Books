using FAMEBooks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.ViewModels.Loan
{
    public class DisplayViewModel
    {
        public string BookId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date Published")]
        public string DatePublished { get; set; }
        public string Status { get; set; }
        public string WillBeAvailable { get; set; }
        public string Category { get; set; }
    }
}
