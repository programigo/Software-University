namespace LearningSystem.Services
{
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Courses.Models;
    using LearningSystem.Services.Students.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainerService
    {
        Task<IEnumerable<CourseListingServiceModel>> CoursesAsync(string trainerId);

        Task<bool> IsTrainer(int courseId, string trainerId);

        Task<IEnumerable<StudentInCourseServiceModel>> StudentsInCourseAsync(int courseId);

        Task<bool> AddGrade(string studentId, int courseId, Grade grade);
    }
}
