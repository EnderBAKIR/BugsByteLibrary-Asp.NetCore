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
    public class HiringService : IHiringService
    {
        private readonly IHiringRepository _hiringRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HiringService(IHiringRepository hiringRepository, IUnitOfWork unitOfWork)
        {
            _hiringRepository = hiringRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Hiring> AddHiringAsync(Hiring hiring)
        {
            hiring.CreatedTime = DateTime.Now;
            hiring.Status = true;
            await _hiringRepository.AddHiringAsync(hiring);
            await _unitOfWork.CommitAsync();
            return hiring;

        }

        public async Task DeleteHiringAsync(Hiring hiring)
        {
            _hiringRepository.DeleteHiringAsync(hiring);
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Hiring>> GetAllHiringAsync()
        {
            return _hiringRepository.GetAllHiringAsync();
        }

        public Task<Hiring> GetHiringByIdAsync(string id)
        {
            return _hiringRepository.GetHiringByIdAsync(id);
        }

        public async Task UpdateHiringAsync(Hiring hiring)
        {
            _hiringRepository.UpdateHiringAsync(hiring);
            await _unitOfWork.CommitAsync();
        }
    }
}
