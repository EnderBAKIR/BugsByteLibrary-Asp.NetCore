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
    public class CourseCodeRepository : ICourseCodeRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<CourseCode> _courseCodeSet;

        public CourseCodeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _courseCodeSet = _appDbContext.Set<CourseCode>();
        }

        public async Task<CourseCode> AddCourseCodeAsync(CourseCode courseCode)
        {
            await _courseCodeSet.AddAsync(courseCode);

            return courseCode;

        }

        public async Task<CourseCode> GetCourseCodeByIdAsnc(string id)
        {
            var courseCode = await _courseCodeSet.Include(x => x.AppUser).Include(x => x.CourseRequest).Where(x => x.Id == id).FirstOrDefaultAsync();

            return courseCode;
        }



        public async Task<IEnumerable<CourseCode>> GetCourseCodeByUserIdAsync(int id)
        {
            var openToWork = await _courseCodeSet.Include(x => x.AppUser).Include(x => x.CourseRequest).Where(x => x.AppUserId == id).ToListAsync();

            return openToWork;
        }

        public void UpdateCourseCodeAsync(CourseCode courseCode)
        {
            _courseCodeSet.Update(courseCode);
        }

        public void DeleteCourseCodeAsync(CourseCode courseCode)
        {
            _courseCodeSet.Remove(courseCode);
        }




    }
}
