using Core.Layer.IRepositories;
using Core.Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Repositories
{
    public class HiringRepository : IHiringRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Hiring> _hiringSet;

        public HiringRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _hiringSet = _appDbContext.Set<Hiring>();
        }

        public async Task<Hiring> AddHiringAsync(Hiring hiring)
        {
            await _hiringSet.AddAsync(hiring);

            return hiring;

        }

        public async Task<IEnumerable<Hiring>> GetAllHiringAsync()
        {
            var hirings = await _hiringSet.Include(x=>x.OpenToWorks).ToListAsync();

            return hirings;
        }

        public async Task<Hiring> GetHiringByIdAsync(string id)
        {
            var hiring = await _hiringSet.Include(x=>x.OpenToWorks).Where(x=>x.Id == id).FirstOrDefaultAsync();

            return hiring;
        }

        public void UpdateHiringAsync(Hiring hiring)
        {
            _hiringSet.Update(hiring);
        }



        public void DeleteHiringAsync(Hiring hiring)
        {
            _hiringSet.Remove(hiring);
        }

        
    }
}
