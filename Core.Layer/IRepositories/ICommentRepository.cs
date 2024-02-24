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


        Task<IEnumerable<Comment>> GetAllComment();

        Task<Comment> AddCommentAsync(Comment comment);

        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId);

        Task<Comment> GetCommentByIdAsync(int id);

        void UpdateComment(Comment comment);

        void DeleteComment(Comment comment);

    }
}
