﻿namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Blog;
    using LearningSystem.Services.Html;
    using LearningSystem.Web.Areas.Blog.Models.Articles;
    using LearningSystem.Web.Infrastructure.Extensions;
    using LearningSystem.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IBlogArticleService articles;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService html;

        public ArticlesController(IBlogArticleService articles, UserManager<User> userManager, IHtmlService html)
        {
            this.articles = articles;
            this.userManager = userManager;
            this.html = html;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        => View(new ArticleListingViewModel
        {
            Articles = await this.articles.AllAsync(page),
            TotalArticles = await this.articles.TotalAsync(),
            CurrentPage = page
        });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.articles.ById(id));

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishArticleFormModel model)
        {
            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.articles.CreateAsync(model.Title, model.Content, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
