using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.ViewModels.Book
{
    public class EditViewModel : CreateViewModel
    {
        [Display(Name = "Last Updated By")]
        public string UpdatedByUserId { get; set; }
    }
}
