﻿namespace BookShop.Services
{
    using Models.Author;
    using Models.Book;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<int> Create(string firstName, string lastName);

        Task<AuthorDetailsServiceModel> Details(int id);

        Task<IEnumerable<BookWithCategoriesServiceModel>> Books(int authorId);

        Task<bool> Exists(int id);
    }
}
