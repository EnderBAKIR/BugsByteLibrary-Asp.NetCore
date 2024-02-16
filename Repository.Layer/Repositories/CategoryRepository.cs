using Core.Layer.IRepositories;
using Core.Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Category> _categorySet;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _categorySet = _appDbContext.Set<Category>();
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _categorySet.Include(x=>x.BlogCategories).ToListAsync();
        }

        public async Task<Category> AddCategoryAsync(Category category) 
        {
         
            await _categorySet.AddAsync(category);
            return category;
        
        }

        public async Task<Category> GetByCategoryIdAsync(int id)
        {
            return await _categorySet.Include(x=>x.BlogCategories).Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public void UpdateCategory(Category category)
        {
             _categorySet.Update(category);
        }

        public void DeleteCategory(Category category) 
        {
            _categorySet.Remove(category);
        
        }
    }
}
