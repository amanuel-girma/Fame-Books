using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.ViewModels.Category
{
    public class DisplayViewModel : EditViewModel
    {
        [Required, DisplayName("Book Count")]
        public int BookCount { get; set; }
    }
}
