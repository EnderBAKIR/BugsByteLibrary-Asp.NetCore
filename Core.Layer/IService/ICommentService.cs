using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IService
{
    public interface ICommentService
    {

        //Commentler modelin kendisi üzerindne listelenecek => blogların içinde.


        Task<IEnumerable<Comment>> GetAllComment();


        Task<Comment> AddCommentAsync(Comment comment);


        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId);

        Task<Comment> GetCommentByIdAsync(int id);

        Task UpdateComment(Comment comment);


        Task DeleteComment(Comment comment);
    }
}
