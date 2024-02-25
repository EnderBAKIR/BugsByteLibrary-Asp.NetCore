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
    public class OpenToWorkService : IOpenToWorkService
    {
        private readonly IOpentoWorkRepository _opentoWorkRepository;

        private readonly IUnitOfWork _unitOfWork;

        public OpenToWorkService(IOpentoWorkRepository opentoWorkRepository, IUnitOfWork unitOfWork)
        {
            _opentoWorkRepository = opentoWorkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OpenToWork> AddOpenToWorkAsync(OpenToWork openToWork)
        {
            openToWork.Id = Guid.NewGuid().ToString();
            openToWork.CreatedTime = DateTime.Now;
            openToWork.Status = true;
            await _opentoWorkRepository.AddOpenToWorkAsync(openToWork);
            await _unitOfWork.CommitAsync();
            return openToWork;
        }

        public async Task DeleteOpenToWorkAsync(OpenToWork openToWork)
        {
             _opentoWorkRepository.DeleteOpenToWorkAsync(openToWork);
            await _unitOfWork.CommitAsync();
        }

        public async Task<OpenToWork> GetOpenToWorkByIdAsnc(string id)
        {
           var openToWork = await _opentoWorkRepository.GetOpenToWorkByIdAsnc(id);

            return openToWork;
        }

        public async Task<IEnumerable<OpenToWork>> GetOpenWorksByUserIdAsync(int id)
        {
            var openToWorks = await _opentoWorkRepository.GetOpenWorksByUserIdAsync(id);

            return openToWorks;
        }

        public async Task UpdateOpenToWorkAsync(OpenToWork openToWork)
        {
            _opentoWorkRepository.UpdateOpenToWorkAsync(openToWork);

            await _unitOfWork.CommitAsync();
        }
    }
}
