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
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<EBook> _bookSet;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            _bookSet = _appDbContext.Set<EBook>();
        }

        public async Task<IEnumerable<EBook>> GetAllBookAsync()
        {
            return await _bookSet.ToListAsync();
        }
        public async Task<EBook> GetBookByIdAsync(int id)
        {

            return await _bookSet.FirstOrDefaultAsync(x=>x.Id==id);

        }

        public async Task<EBook> AddBookAsync(EBook book)
        {
            await _bookSet.AddAsync(book);
            return book;
        }

        public  void UpdateBookAsync(EBook book)
        {
             _bookSet.Update(book);
            
        }
        public void DeleteBookAsync(EBook book)
        {
            _bookSet.Remove(book);
        }

    }
}
