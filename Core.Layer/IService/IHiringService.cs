using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IService
{
    public interface IHiringService
    {
        Task<Hiring> AddHiringAsync(Hiring hiring);

        Task<IEnumerable<Hiring>> GetAllHiringAsync();

        Task<Hiring> GetHiringByIdAsync(string id);

        Task UpdateHiringAsync(Hiring hiring);

        Task DeleteHiringAsync(Hiring hiring);
    }
}
