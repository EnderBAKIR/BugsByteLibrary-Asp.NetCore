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
    public class CourseRequestRepository : ICourseRequestRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<CourseRequest> _courseRequestSet;

        public CourseRequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _courseRequestSet = _appDbContext.Set<CourseRequest>();
        }

        public async Task<CourseRequest> AddCourseAsync(CourseRequest courseRequest)
        {
            await _courseRequestSet.AddAsync(courseRequest);

            return courseRequest;
        }

        public async Task<IEnumerable<CourseRequest>> GetAllCourseAsync()
        {
            return await _courseRequestSet.Include(x => x.CourseCodes).ThenInclude(x => x.AppUser).ToListAsync();
        }

        public async Task<CourseRequest> GetCourseByIdAsync(string id)
        {
            return await _courseRequestSet.Include(x=>x.CourseCodes).ThenInclude(x=>x.AppUser).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void DeleteCourseAsync(CourseRequest courseRequest)
        {
            _courseRequestSet.Remove(courseRequest);
        }

        public void UpdateCourseAsync(CourseRequest courseRequest)
        {
            _courseRequestSet.Update(courseRequest);
        }
    }
}
