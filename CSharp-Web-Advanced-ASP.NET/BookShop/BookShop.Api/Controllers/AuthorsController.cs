namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Authors;
    using Services;
    using System.Threading.Tasks;

    public class AuthorsController : BaseApiController
    {
        public readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet(WebConstants.WithId)]
        public async Task<IActionResult> Get(int id) => this.OkOrNotFound(await this.authors.Details(id));

        [HttpGet(WebConstants.WithId + "/books")]
        public async Task<IActionResult> GetBooks(int id) => this.Ok(await this.authors.Books(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel model)
        {     
            var id = await this.authors.Create(
                model.FirstName,
                model.LastName);

            return Ok(id);
        }
    }
}
