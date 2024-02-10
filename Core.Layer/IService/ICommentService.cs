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
        Task<Comment> AddCommentAsync(Comment comment);
    }
}
