using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IService
{
    public interface ICourseCodeService
    {
        Task<CourseCode> AddCourseCodeAsync(CourseCode courseCode);

        Task<CourseCode> GetCourseCodeByIdAsnc(string id);

        Task<IEnumerable<CourseCode>> GetCourseCodeByUserIdAsync(int id);

        Task UpdateCourseCodeAsync(CourseCode courseCode);

        Task DeleteCourseCodeAsync(CourseCode courseCode);
    }
}
