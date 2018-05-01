namespace LearningSystem.Web.Models.Home
{
    using LearningSystem.Services.Courses.Models;
    using System.Collections.Generic;

    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; }
    }
}
