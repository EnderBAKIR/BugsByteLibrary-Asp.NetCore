using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface IHiringRepository
    {
        Task<Hiring> AddHiringAsync(Hiring hiring);

        Task<IEnumerable<Hiring>> GetAllHiringAsync();

        Task<Hiring> GetHiringByIdAsync(string id);

        void UpdateHiringAsync(Hiring hiring);

        void DeleteHiringAsync(Hiring hiring);
    }
}
