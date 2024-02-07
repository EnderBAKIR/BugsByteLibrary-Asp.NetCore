using Core.Layer.IRepositories;
using Core.Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Repositories
{
    public class BlogRepository : IBlogRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Blog> _blogSet;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _blogSet = _appDbContext.Set<Blog>();
        }



        public async Task<List<Blog>> GetAllBlogAsync()
        {
            return await _blogSet.Include(x => x.AppUser).ToListAsync();
        }

        public async Task<Blog> AddBlogAsnyc(Blog blog)
        {
            await _blogSet.AddAsync(blog);

            return blog;
        }

        public void UpdateBlog(Blog blog)
        {
            _blogSet.Update(blog);
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _blogSet.FindAsync(id);
        }

        public void DeleteBlog(Blog blog)
        {
            _blogSet.Remove(blog);
        }
    }
}
