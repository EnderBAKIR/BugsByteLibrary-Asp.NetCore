using Core.Layer.IRepositories;
using Core.Layer.IService;
using Core.Layer.IUnitOfWorks;
using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Services
{
    public class CourseRequestService : ICourseRequestService
    {
        private readonly ICourseRequestRepository _courseRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CourseRequestService(ICourseRequestRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseRequest> AddCourseAsync(CourseRequest courseRequest)
        {
            courseRequest.Id = Guid.NewGuid().ToString();
            courseRequest.Status = true;
            await _courseRepository.AddCourseAsync(courseRequest);
            await _unitOfWork.CommitAsync();

            return courseRequest;
        }

        public async Task DeleteCourseAsync(CourseRequest courseRequest)
        {
            _courseRepository.DeleteCourseAsync(courseRequest);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CourseRequest>> GetAllCourseAsync()
        {
            return await _courseRepository.GetAllCourseAsync();
        }

        public async Task<CourseRequest> GetCourseByIdAsync(string id)
        {
           return await _courseRepository.GetCourseByIdAsync(id);
        }

        public async Task UpdateCourseAsync(CourseRequest courseRequest)
        {
            _courseRepository.UpdateCourseAsync(courseRequest);

            await _unitOfWork.CommitAsync();
        }
    }
}
