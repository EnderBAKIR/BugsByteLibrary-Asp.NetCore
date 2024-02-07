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
        Task<List<Blog>> GetAllBlogAsync();

        Task<Blog> AddBlogAsnyc(Blog blog);

        Task UpdateBlog(Blog blog);

        Task<Blog> GetBlogByIdAsync(int id);

        Task DeleteBlog(Blog blog);

    }
}
