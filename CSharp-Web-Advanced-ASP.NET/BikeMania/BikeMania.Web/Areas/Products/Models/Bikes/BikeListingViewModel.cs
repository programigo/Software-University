namespace BikeMania.Web.Areas.Products.Models.Bikes
{
    using Services;
    using Services.Bike.Models;
    using System;
    using System.Collections.Generic;

    public class BikeListingViewModel
    {
        public IEnumerable<BikeListingServiceModel> Bikes { get; set; }

        public int TotalBikes { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalBikes / ServiceConstants.BikeListingPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
