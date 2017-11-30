﻿namespace LearningSystem.Services
{
    using LearningSystem.Services.Users.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserProfileServiceModel> ProfileAsync(string username);

        Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText);

        Task<byte[]> GetPdfCertificate(string studentId, int courseId);
    }
}
