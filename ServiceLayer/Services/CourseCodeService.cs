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
    public class CourseCodeService : ICourseCodeService
    {
        private readonly ICourseCodeRepository _courseCodeRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CourseCodeService(ICourseCodeRepository courseCodeRepository, IUnitOfWork unitOfWork)
        {
            _courseCodeRepository = courseCodeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseCode> AddCourseCodeAsync(CourseCode courseCode)
        {
            courseCode.Id = Guid.NewGuid().ToString();
            courseCode.Status = true;
            
            await _courseCodeRepository.AddCourseCodeAsync(courseCode);
            await _unitOfWork.CommitAsync();

            return courseCode;
        }

        public async Task DeleteCourseCodeAsync(CourseCode courseCode)
        {
            _courseCodeRepository.DeleteCourseCodeAsync(courseCode);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CourseCode>> GetCourseCodeByUserIdAsync(int id)
        {
            return await _courseCodeRepository.GetCourseCodeByUserIdAsync(id);
        }

        public async Task<CourseCode> GetCourseCodeByIdAsnc(string id)
        {
            return await _courseCodeRepository.GetCourseCodeByIdAsnc(id);
        }

        public async Task UpdateCourseCodeAsync(CourseCode courseCode)
        {
           _courseCodeRepository.UpdateCourseCodeAsync(courseCode);

            await _unitOfWork.CommitAsync();
        }
    }
}
