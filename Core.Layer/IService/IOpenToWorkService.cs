using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IService
{
    public interface IOpenToWorkService
    {
        Task<OpenToWork> AddOpenToWorkAsync(OpenToWork openToWork);

        Task<IEnumerable<OpenToWork>> GetOpenWorksByUserIdAsync(int id);

        Task UpdateOpenToWorkAsync(OpenToWork openToWork);

        Task DeleteOpenToWorkAsync(OpenToWork openToWork);

        Task<OpenToWork> GetOpenToWorkByIdAsnc(string id);
    }
}
