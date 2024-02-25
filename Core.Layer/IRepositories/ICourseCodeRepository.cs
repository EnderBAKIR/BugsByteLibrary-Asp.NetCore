using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface ICourseCodeRepository
    {
        Task<CourseCode> AddCourseCodeAsync(CourseCode courseCode);

        Task<CourseCode> GetCourseCodeByIdAsnc(string id);

        Task<IEnumerable<CourseCode>> GetCourseCodeByUserIdAsync(int id);

        void UpdateCourseCodeAsync(CourseCode courseCode);

        void DeleteCourseCodeAsync(CourseCode courseCode);
    }
}
