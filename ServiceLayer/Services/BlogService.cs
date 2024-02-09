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
    public class BlogService : IBlogService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlogRepository _blogRepository;
        

        public BlogService(IUnitOfWork unitOfWork, IBlogRepository blogRepository)
        {
            _unitOfWork = unitOfWork;
            _blogRepository = blogRepository;
        }

        public async Task<Blog> AddBlogAsnyc(Blog blog)
        {
          
            
                 await _blogRepository.AddBlogAsnyc(blog);
              await  _unitOfWork.CommitAsync();

                return blog;
                
            
           
        }

        public async Task DeleteBlog(Blog blog)
        {
            _blogRepository.DeleteBlog(blog);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllBlogAsync()
        {
           return await _blogRepository.GetAllBlogAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
           return await _blogRepository.GetBlogByIdAsync(id);
        }

        public async Task UpdateBlog(Blog blog)
        {
           _blogRepository.UpdateBlog(blog);
            await _unitOfWork.CommitAsync();
        }
    }
}
