namespace LearningSystem.Web.Models.Home
{
    using LearningSystem.Services.Courses.Models;
    using LearningSystem.Services.Users.Models;
    using System.Collections.Generic;

    public class SearchViewModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; } = new List<CourseListingServiceModel>();

        public IEnumerable<UserListingServiceModel> Users { get; set; } = new List<UserListingServiceModel>();

        public string Searchtext { get; set; }
    }
}
