using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface ICommentRepository
    {
        Task<Comment> AddCommentAsync(Comment comment);

        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId);
    }
}
