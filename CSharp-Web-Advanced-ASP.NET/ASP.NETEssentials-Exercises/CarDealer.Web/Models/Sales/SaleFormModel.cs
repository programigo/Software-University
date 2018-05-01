namespace CarDealer.Web.Models.Sales
{
    using CarDealer.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SaleFormModel
    {
        public Customer Customer { get; set; }

        public Car Car { get; set; }

        [Range(0, 100)]
        public double Discount { get; set; }

        public IEnumerable<int> SelectedCustomers { get; set; }

        [Display(Name = "Parts")]
        public IEnumerable<SelectListItem> AllCustomers { get; set; }
    }
}
