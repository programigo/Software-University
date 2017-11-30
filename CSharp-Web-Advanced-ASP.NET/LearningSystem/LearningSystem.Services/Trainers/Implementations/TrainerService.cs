namespace LearningSystem.Services.Trainers.Implementations
{
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Services.Courses.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LearningSystem.Services.Students.Models;
    using LearningSystem.Data.Models;

    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;

        public TrainerService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddGradeAsync(string studentId, int courseId, Grade grade)
        {
            var studentInCourse = await this.db.FindAsync<StudentCourse>(studentId, courseId);

            if (studentInCourse == null)
            {
                return false;
            }

            studentInCourse.Grade = grade;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> CoursesAsync(string trainerId)
           => await this.db
            .Courses
            .Where(c => c.TrainerId == trainerId)
            .ProjectTo<CourseListingServiceModel>()
            .ToListAsync();

        public async Task<byte[]> GetExamSubmissionAsync(string studentId, int courseId)
        {
            var studentInCourse = await this.db.FindAsync<StudentCourse>(studentId, courseId);

            if (studentInCourse == null)
            {
                return null;
            }

            return studentInCourse.ExamSubmission;
        }

        public async Task<SudentInCourseNameServiceModel> StudentInCourseNamesAsync(string studentId, int courseId)
        {
            var username = await this.db
                        .Users
                        .Where(u => u.Id == studentId)
                        .Select(u => u.UserName)
                        .FirstOrDefaultAsync();

            if (username == null)
            {
                return null;
            }

            var courseName = await this.db
                        .Courses
                        .Where(c => c.Id == courseId)
                        .Select(c => c.Name)
                        .FirstOrDefaultAsync();

            if (courseName == null)
            {
                return null;
            }

            return new SudentInCourseNameServiceModel
            {
                Username = username,
                CourseName = courseName
            };
        }

        public async Task<bool> IsTrainer(int courseId, string trainerId)
            => await this.db
                    .Courses
                    .AnyAsync(c => c.Id == courseId && c.TrainerId == trainerId);

        public async Task<IEnumerable<StudentInCourseServiceModel>> StudentsInCourseAsync(int courseId)
            => await this.db
                    .Courses
                    .Where(c => c.Id == courseId)
                    .SelectMany(c => c.Students.Select(s => s.Student))
                    .ProjectTo<StudentInCourseServiceModel>(new { courseId })
                    .ToListAsync();
    }
}
