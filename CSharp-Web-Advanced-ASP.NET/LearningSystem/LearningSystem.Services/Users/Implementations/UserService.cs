namespace LearningSystem.Services.Users.Implementations
{
    using AutoMapper.QueryableExtensions;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Users.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;
        private readonly IPdfGenerator pdfGenerator;

        public UserService(LearningSystemDbContext db, IPdfGenerator pdfGenerator)
        {
            this.db = db;
            this.pdfGenerator = pdfGenerator;
        }

        public async Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                           .Users
                           .OrderBy(u => u.UserName)
                           .Where(u => u.Name.ToLower().Contains(searchText.ToLower()))
                           .ProjectTo<UserListingServiceModel>()
                           .ToListAsync();
        }

        public async Task<byte[]> GetPdfCertificate(string studentId, int courseId)
        {
            var studentInCourse = await this.db
                        .FindAsync<StudentCourse>(studentId, courseId);

            if (studentInCourse == null)
            {
                return null;
            }

            var certificateInfo = await this.db
                    .Courses
                    .Where(c => c.Id == courseId)
                    .Select(c => new
                    {
                        CourseName = c.Name,
                        CourseStartDate = c.StartDate,
                        CourseEndDate = c.EndDate,
                        StudentName = c.Students
                                .Where(s => s.StudentId == studentId)
                                .Select(s => s.Student.Name)
                                .FirstOrDefault(),
                        StudentGrade = c.Students
                                .Where(s => s.StudentId == studentId)
                                .Select(s => s.Grade)
                                .FirstOrDefault(),
                        Trainer = c.Trainer.Name
                    })
                    .FirstOrDefaultAsync();

            return this.pdfGenerator.GeneratePdfFromHtml(string.Format(
                ServiceConstants.PdfCertificateFormat,
                certificateInfo.CourseName,
                certificateInfo.CourseStartDate.ToShortDateString(),
                certificateInfo.CourseEndDate.ToShortDateString(),
                certificateInfo.StudentName,
                certificateInfo.StudentGrade,
                certificateInfo.Trainer,
                DateTime.UtcNow.ToShortDateString()));
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
            => await this.db
            .Users
            .Where(u => u.Id == id)
            .ProjectTo<UserProfileServiceModel>(new { studentId = id })
            .FirstOrDefaultAsync();
    }
}
