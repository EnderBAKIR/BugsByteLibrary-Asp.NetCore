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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            comment.SolverComment = false;
            comment.CreateDate = DateTime.Now;
            comment.Status = true;
            await _commentRepository.AddCommentAsync(comment);
            await _unitOfWork.CommitAsync();

            return comment;
        }

        public async Task DeleteComment(Comment comment)
        {
             _commentRepository.DeleteComment(comment);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllComment()
        {
            return await _commentRepository.GetAllComment();
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
          return await _commentRepository.GetCommentByIdAsync(id);
        }

        public Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId)
        {
            return _commentRepository.GetCommentsByUserIdAsync(userId);
        }

        public async Task UpdateComment(Comment comment)
        {
            _commentRepository.UpdateComment(comment);

            await _unitOfWork.CommitAsync();
        }
    }
}
