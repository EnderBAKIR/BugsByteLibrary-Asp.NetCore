using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IService
{
    public interface ICourseRequestService
    {
        Task<CourseRequest> AddCourseAsync(CourseRequest courseRequest);


        Task<IEnumerable<CourseRequest>> GetAllCourseAsync();


        Task<CourseRequest> GetCourseByIdAsync(string id);

        Task DeleteCourseAsync(CourseRequest courseRequest);

        Task UpdateCourseAsync(CourseRequest courseRequest);
    }
}
