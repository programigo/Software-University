namespace CarDealer.Web.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Sales;
    using Services;
    using System.Collections.Generic;
    using System.Linq;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService sales;
        private readonly ICustomerService customers;

        public SalesController(ISaleService sales, ICustomerService customers)
        {
            this.sales = sales;
            this.customers = customers;
        }

        [Route("")]
        public IActionResult All()
        {
            return this.View(this.sales.All());
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            return this.ViewOrNotFound(this.sales.Details(id));
        }

        [Route(nameof(Create))]
        public IActionResult Create()
        {
            return this.View(new SaleFormModel
            {
                AllCustomers = this.GetCustomersSelectItems()
            });
        }

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(SaleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //TODO: Redirect to Review Sale action(not created yet, it should be created here in SalesController)
            return RedirectToAction(nameof(Details));
        }

        private IEnumerable<SelectListItem> GetCustomersSelectItems()
        {
            return this.customers
                .All()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
        }
    }
}
