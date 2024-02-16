using Core.Layer.IRepositories;
using Core.Layer.IService;
using Core.Layer.IUnitOfWorks;
using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
            await _unitOfWork.CommitAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(Category category)
        {
             _categoryRepository.DeleteCategory(category);
            await _unitOfWork.CommitAsync();
            
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
           return await _categoryRepository.GetAllCategoryAsync();
        }

        public async Task<Category> GetByCategoryIdAsync(int id)
        {
           return await _categoryRepository.GetByCategoryIdAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _categoryRepository.UpdateCategory(category);
            await _unitOfWork.CommitAsync();
        }
    }
}
