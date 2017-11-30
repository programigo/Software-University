namespace LearningSystem.Services
{
    using System.Collections.Generic;
    using Courses.Models;
    using System.Threading.Tasks;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> ActiveAsync();

        Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText);

        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;
        
        Task<bool> SignUpStudentAsync(int courseId, string userId);

        Task<bool> SignOutStudentAsync(int courseId, string userId);

        Task<bool> StudentIsEnrolledInCourseAsync(int courseId, string userId);
        Task<bool> SaveExamSubmission(int courseId, string studentId, byte[] examSubmission);
    }
}
