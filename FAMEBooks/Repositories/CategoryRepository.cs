using FAMEBooks.Models;
using FAMEBooks.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;


        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Category>> Categories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> AddAsync(CreateViewModel category)
        {
            var newCategory = new Category { CategoryId = Guid.NewGuid(), CategoryName = category.CategoryName };
            await context.Categories.AddAsync(newCategory);
            await context.SaveChangesAsync();
            return newCategory;
        }

        public async Task<Category> DeleteAsync(Guid id)
        {
            var result = await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            context.Categories.Remove(result);
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<List<DisplayViewModel>> GetCategories()
        {
            var categories = await (from c in context.Categories
                                    select new DisplayViewModel
                                    {
                                        CategoryId = c.CategoryId,
                                        CategoryName = c.CategoryName,
                                        BookCount = c.Books.Count()
                                    }).ToListAsync();
            return categories;
        }

        public async Task<List<DisplayViewModel>> GetCategories(string categoryName)
        {
            var categories = (from c in context.Categories
                              select new DisplayViewModel
                              {
                                  CategoryId = c.CategoryId,
                                  CategoryName = c.CategoryName,
                                  BookCount = c.Books.Count()
                              }).Where(c => c.CategoryName == categoryName).ToListAsync();
            return await categories;
        }

        public async Task<Category> GetCategory(Guid id)
        {
            var category = context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            return await category;
        }

        public async Task<Category> UpdateAsync(EditViewModel category)
        {
            var result = await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);
            if (result == null)
            {
                return null;
            }
            result.CategoryName = category.CategoryName;
            context.Entry<Category>(result).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return result;
        }



    }
}
