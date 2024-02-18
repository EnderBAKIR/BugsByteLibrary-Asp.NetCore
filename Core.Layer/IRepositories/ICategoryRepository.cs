using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();

        Task<Category> AddCategoryAsync(Category category);

        Task<Category> GetByCategoryIdAsync(int id);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);


        

    }
}
