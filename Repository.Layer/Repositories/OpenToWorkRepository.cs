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
    public class OpenToWorkRepository : IOpentoWorkRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<OpenToWork> _openToWorkSet;

        public OpenToWorkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _openToWorkSet =  _appDbContext.Set<OpenToWork>();
        }



        public async Task<OpenToWork> AddOpenToWorkAsync(OpenToWork openToWork)
        {
            await _openToWorkSet.AddAsync(openToWork);

            return openToWork;

        }

        public async Task<OpenToWork> GetOpenToWorkByIdAsnc(string id)
        {
            var openToWork = await _openToWorkSet.Include(x=>x.AppUser).Include(x=>x.Hiring).Where(x=>x.Id == id).FirstOrDefaultAsync();

            return openToWork;
        }



        public async Task<IEnumerable<OpenToWork>> GetOpenWorksByUserIdAsync(int id)
        {
            var openToWork = await _openToWorkSet.Include(x => x.AppUser).Include(x=>x.Hiring).Where(x => x.AppUserId == id).ToListAsync();

            return openToWork;
        }

        public void UpdateOpenToWorkAsync(OpenToWork openToWork)
        {
            _openToWorkSet.Update(openToWork);
        }

        public void DeleteOpenToWorkAsync(OpenToWork openToWork)
        {
            _openToWorkSet.Remove(openToWork);
        }
        
    }
}
