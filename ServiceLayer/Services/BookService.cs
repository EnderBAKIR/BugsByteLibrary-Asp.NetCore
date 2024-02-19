using Core.Layer.IRepositories;
using Core.Layer.IService;
using Core.Layer.IUnitOfWorks;
using Core.Layer.Models;
using Repository.Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Services
{
    public class BookService : IBookService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;

        public BookService(IUnitOfWork unitOfWork, IBookRepository bookRepository)
        {
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
        }

        public async Task<EBook> AddBookAsync(EBook book)
        {
            book.CreatedDate = DateTime.Now;
            
            await _bookRepository.AddBookAsync(book);
            await _unitOfWork.CommitAsync();
            return book;
        }

        public async void DeleteBookAsync(EBook book)
        {
            _bookRepository.DeleteBookAsync(book);
            await _unitOfWork.CommitAsync();

        }

        public async Task<IEnumerable<EBook>> GetAllBookAsync()
        {
           return await _bookRepository.GetAllBookAsync();
        }

        public async Task<EBook> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async void UpdateBookAsync(EBook book)
        {
            _bookRepository.UpdateBookAsync(book);
            await _unitOfWork.CommitAsync();
        }
    }
}
