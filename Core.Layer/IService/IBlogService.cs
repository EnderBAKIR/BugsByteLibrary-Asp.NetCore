using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IService
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllBlogAsync();

        Task<Blog> AddBlogAsnyc(Blog blog);

        Task UpdateBlog(Blog blog);

        Task<Blog> GetBlogByIdAsync(int id);

        Task DeleteBlog(Blog blog);

        Task UpdateBlogCategoriesAsync(Blog blog);
        Task DeleteBlogCategoriesAsync(Blog blog);

        
    }
}
