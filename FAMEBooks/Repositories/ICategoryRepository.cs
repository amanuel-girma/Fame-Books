using FAMEBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAMEBooks.ViewModels.Category;

namespace FAMEBooks.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<DisplayViewModel>> GetCategories();
        public Task<Category> GetCategory(Guid id);
        public Task<List<DisplayViewModel>> GetCategories(string title);
        public Task<Category> AddAsync(CreateViewModel category);
        public Task<Category> UpdateAsync(EditViewModel category);
        public Task<Category> DeleteAsync(Guid id);
        public Task<List<Category>> Categories();
    }
}
