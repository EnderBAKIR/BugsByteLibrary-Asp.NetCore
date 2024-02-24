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
    public class BlogRepository : IBlogRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Blog> _blogSet;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _blogSet = _appDbContext.Set<Blog>();
        }



        public async Task<IEnumerable<Blog>> GetAllBlogAsync()
        {
            return await _blogSet.Include(x => x.AppUser).Include(x=>x.BlogCategories).ThenInclude(x=>x.Category).ToListAsync();
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
            return await _blogSet.Include(x => x.AppUser).Include(x => x.Comments).FirstOrDefaultAsync(x=>x.Id==id);
            
        }


        public void DeleteBlog(Blog blog)
        {
            _blogSet.Remove(blog);
        }




        public async Task DeleteBlogCategoriesAsync(Blog blog)
        {
            // BlogCategories tablosundan belirli bir bloga ait kategorileri sil
            var blogCategories = await _appDbContext.BlogsCategories.Where(x => x.BlogId == blog.Id).ToListAsync();
                
               

            _appDbContext.BlogsCategories.RemoveRange(blogCategories);
           
        }

        public async Task UpdateBlogCategoriesAsync(Blog blog)
        {
            var blogCategories = await _appDbContext.BlogsCategories.Where(x => x.BlogId == blog.Id).ToListAsync();



            _appDbContext.BlogsCategories.UpdateRange(blogCategories);

        }

        public async Task<IEnumerable<Blog>> GetBlogsByUserIdAsync(int userId)
        {
          var values =   await _blogSet.Include(x => x.AppUser).Include(x => x.BlogCategories).ThenInclude(x => x.Category).Where(x=>x.AppUserId == userId).ToListAsync();

            return values;
        }
     
       
    }
}
