using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogAsync();

        Task<Blog> AddBlogAsnyc(Blog blog);

        void UpdateBlog(Blog blog);

        Task<Blog> GetBlogByIdAsync(int id);

        void DeleteBlog(Blog blog);

        Task UpdateBlogCategoriesAsync(Blog blog);
        Task DeleteBlogCategoriesAsync(Blog blog);

        Task<IEnumerable<Blog>> GetBlogsByUserIdAsync(int userId);


    }
}
