using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface IOpentoWorkRepository
    {
        Task<OpenToWork> AddOpenToWorkAsync(OpenToWork openToWork);

        Task<IEnumerable<OpenToWork>> GetOpenWorksByUserIdAsync(int id);

        void UpdateOpenToWorkAsync(OpenToWork openToWork);

        void DeleteOpenToWorkAsync(OpenToWork openToWork);

        Task<OpenToWork> GetOpenToWorkByIdAsnc(string id);
    }
}
