﻿namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Books;
    using Services;
    using System.Threading.Tasks;

    public class BooksController : BaseApiController
    {
        private readonly IBookService books;
        private readonly IAuthorService authors;

        public BooksController(IBookService books, IAuthorService authors)
        {
            this.books = books;
            this.authors = authors;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
            => this.Ok(await this.books.All(search));

        [HttpGet(WebConstants.WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.books.Details(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]CreateBookRequestModel model)
        {
            if (!await this.authors.Exists(model.AuthorId))
            {
                return BadRequest("Author does not exist.");
            }

            var id = await this.books.Create(model.Title, model.Description, model.Price, model.Copies, model.Edition, model.AgeRestriction, model.ReleaseDate, model.AuthorId, model.Categories);

            return Ok(id);
        }
    }
}
