using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();

        Task<Category> AddCategoryAsync(Category category);

        Task<Category> GetByCategoryIdAsync(int id);

        Task UpdateCategoryAsync(Category category);

        Task DeleteCategoryAsync(Category category);
    }
}
