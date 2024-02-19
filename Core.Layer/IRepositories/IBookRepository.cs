using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<EBook>> GetAllBookAsync();

        Task<EBook> GetBookByIdAsync(int id);

        Task<EBook> AddBookAsync(EBook book);

        void UpdateBookAsync(EBook book);

        void DeleteBookAsync(EBook book);
    }
}
