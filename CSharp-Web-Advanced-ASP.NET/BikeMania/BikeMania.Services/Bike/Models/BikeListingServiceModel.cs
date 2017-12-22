namespace BikeMania.Services.Bike.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class BikeListingServiceModel : IMapFrom<Bike>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int FrameSize { get; set; }

        public string WheelesMake { get; set; }

        public string ForkMake { get; set; }

        public string TiresMake { get; set; }

        public string ShiftersMake { get; set; }

        public string FrontDerailleur { get; set; }

        public string RearDerailleur { get; set; }

        public string Chain { get; set; }

        public string Saddle { get; set; }

        public string Handlebar { get; set; }

        public string Brakes { get; set; }

        public string Color { get; set; }

        public string BrakeLevers { get; set; }

        public string BatteryMake { get; set; }

        public int? BatteryPower { get; set; }

        public string BarTape { get; set; }

        public string RearShockMake { get; set; }

        public string Kickstand { get; set; }

        public string UserId { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Bike, BikeListingServiceModel>()
                .ForMember(u => u.UserId, cfg => cfg.MapFrom(b => b.UserId));
    }
}
