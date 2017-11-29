namespace LearningSystem.Web.Models.Courses
{
    using LearningSystem.Services.Courses.Models;

    public class CourseDetailsViewModel
    { 
        public CourseDetailsServiceModel Course { get; set; }

        public bool UserIsEnrolledInCourse { get; set; }
    }
}
