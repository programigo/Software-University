namespace News.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using News.Data;
    using News.Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Xunit;
 
    public class EndPointTests
    {
        private NewsDbContext Context
        {
            get
            {
                var dbOptions = new DbContextOptionsBuilder<NewsDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .Options;

                return new NewsDbContext(dbOptions);
            }
        }

        [Fact]
        public void NewsControllerGetAllNewsShould_ReturnOkStatusCode()
        {
            var context = this.Context;

            this.PopulateData(context);

            var newsController = new NewsController(context);

            var returnedData = (newsController.GetAllNews() as OkObjectResult).Value as IEnumerable<Data.Models.News>;
            var testData = this.GetTestData();

            foreach (var returnedModel in returnedData)
            {
                var testModel = testData.First(n => n.Id == returnedModel.Id);

                Assert.NotNull(testModel);
                Assert.True(this.CompareNewsExact(returnedModel, testModel));
            }
        }

        [Fact]
        public void NewsControllerPostNewsWithCorrectDataShould_ReturnCreatedStatusCode()
        {
            var context = this.Context;

            var testModel = this.GetTestData().First();

            var newsController = new NewsController(context);

            Assert.IsType<CreatedAtActionResult>(newsController.PostNews(testModel));
        }

        [Fact]
        public void NewsControllerPostNewsWithCorrectDataShould_ReturnCreatedNews()
        {
            var context = this.Context;

            var testModel = this.GetTestData().First();

            var newsController = new NewsController(context);

            var returnedModel = (newsController.PostNews(testModel) as CreatedAtActionResult).Value as Data.Models.News;

            Assert.True(this.CompareNewsExact(returnedModel, testModel));
        }

        [Fact]
        public void NewsControllerPostNewsWithIncorrectDataShould_ReturnBadRequestStatusCode()
        {
            var context = this.Context;

            var testModel = this.GetTestData().First();

            var newsController = new NewsController(context);

            newsController.ModelState.AddModelError("Invalid Data", "Invalid Data");

            Assert.IsType<BadRequestObjectResult>(newsController.PostNews(testModel));
        }

        private IEnumerable<Data.Models.News> GetTestData()
        {
            return new List<Data.Models.News>()
            {
                new Data.Models.News{Id = 1, Title = "Neshto", Content = "Neshto si", PublishDate = DateTime.ParseExact("13/05/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new Data.Models.News{Id = 2, Title = "Course", Content = "C Sharp Advanced course", PublishDate = DateTime.ParseExact("10/07/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new Data.Models.News{Id = 3, Title = "Football", Content = "El classico day", PublishDate = DateTime.ParseExact("13/11/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new Data.Models.News{Id = 4, Title = "JS Core", Content = "Javascript course", PublishDate = DateTime.ParseExact("12/03/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
            };
        }

        private void PopulateData(NewsDbContext context)
        {
            context.AddRange(this.GetTestData());
            context.SaveChanges();
        }

        private bool CompareNewsExact(Data.Models.News thisNews, Data.Models.News otherNews)
        {
            return thisNews.Id == otherNews.Id
                && thisNews.Title == otherNews.Title
                && thisNews.Content == otherNews.Content
                && thisNews.PublishDate == otherNews.PublishDate;
        }
    }
}
