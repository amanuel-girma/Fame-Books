using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FAMEBooks.ViewModels.Category
{
    public class CreateViewModel
    {
        [DisplayName("Category Name"), Required]
        public string CategoryName { get; set; }
    }
}
