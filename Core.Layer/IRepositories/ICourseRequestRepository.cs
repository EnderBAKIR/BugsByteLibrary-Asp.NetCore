using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface ICourseRequestRepository
    {

        Task<CourseRequest> AddCourseAsync(CourseRequest courseRequest);


        Task<IEnumerable<CourseRequest>> GetAllCourseAsync();


        Task<CourseRequest> GetCourseByIdAsync(string id);

        void DeleteCourseAsync(CourseRequest courseRequest);

        void UpdateCourseAsync(CourseRequest courseRequest);

    }
}
