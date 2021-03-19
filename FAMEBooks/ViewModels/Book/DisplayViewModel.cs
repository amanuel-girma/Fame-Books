using FAMEBooks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.ViewModels.Book
{
    public class DisplayViewModel : EditViewModel
    {
        public Status Status { get; set; }
        public string Category { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; internal set; }
    }
}
