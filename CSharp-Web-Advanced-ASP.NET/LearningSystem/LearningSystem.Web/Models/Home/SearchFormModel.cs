﻿namespace LearningSystem.Web.Models.Home
{
    using LearningSystem.Services.Courses.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Search In Users")]
        public bool SearchInUsers { get; set; } = true;

        [Display(Name = "Search In Courses")]
        public bool SearchInCourses { get; set; } = true;
    }
}
