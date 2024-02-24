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
   public  class CommentRepository : ICommentRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Comment> _commentSet;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _commentSet = _appDbContext.Set<Comment>();
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
           await _commentSet.AddAsync(comment);

            return comment;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId)
        {
            var values = await _commentSet.Include(x=>x.Blog).Include(x=>x.Appuser).Where(x=>x.AppUserId == userId).ToListAsync();

            return values;
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
           return await _commentSet.Include(x=>x.Appuser).Include(x=>x.Blog).FirstOrDefaultAsync(x=>x.Id == id);

            
        }


        public void UpdateComment(Comment comment)
        {
            _commentSet.Update(comment);
        }
    }
}
