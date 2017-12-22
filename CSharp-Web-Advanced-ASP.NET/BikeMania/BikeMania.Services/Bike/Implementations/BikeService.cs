namespace BikeMania.Services.Bike.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BikeService : IBikeService
    {
        private readonly BikeManiaDbContext db;

        public BikeService(BikeManiaDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BikeListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Bikes
                .OrderByDescending(b => b.Id)
                .Skip((page - 1) * ServiceConstants.BikeListingPageSize)
                .Take(ServiceConstants.BikeListingPageSize)
                .ProjectTo<BikeListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<BikeListingServiceModel>> RoadAsync(int page = 1)
            => await this.db
                    .Bikes
                    .Where(b => b.BarTape != null)
                    .OrderByDescending(b => b.Id)
                    .Skip((page - 1) * ServiceConstants.BikeListingPageSize)
                    .Take(ServiceConstants.BikeListingPageSize)
                    .ProjectTo<BikeListingServiceModel>()
                    .ToListAsync();

        public async Task<IEnumerable<BikeListingServiceModel>> MountainAsync(int page = 1)
        => await this.db
                    .Bikes
                    .Where(b => b.BrakeLevers != null)
                    .OrderByDescending(b => b.Id)
                    .Skip((page - 1) * ServiceConstants.BikeListingPageSize)
                    .Take(ServiceConstants.BikeListingPageSize)
                    .ProjectTo<BikeListingServiceModel>()
                    .ToListAsync();

        public async Task<IEnumerable<BikeListingServiceModel>> SuspensionMountainAsync(int page = 1)
        => await this.db
                    .Bikes
                    .Where(b => b.RearShockMake != null)
                    .OrderByDescending(b => b.Id)
                    .Skip((page - 1) * ServiceConstants.BikeListingPageSize)
                    .Take(ServiceConstants.BikeListingPageSize)
                    .ProjectTo<BikeListingServiceModel>()
                    .ToListAsync();

        public async Task<IEnumerable<BikeListingServiceModel>> ElectricAsync(int page = 1)
        => await this.db
                    .Bikes
                    .Where(b => b.BatteryMake != null && b.BatteryPower != null)
                    .OrderByDescending(b => b.Id)
                    .Skip((page - 1) * ServiceConstants.BikeListingPageSize)
                    .Take(ServiceConstants.BikeListingPageSize)
                    .ProjectTo<BikeListingServiceModel>()
                    .ToListAsync();

        public async Task<IEnumerable<BikeListingServiceModel>> KidsAsync(int page = 1)
        => await this.db
                    .Bikes
                    .Where(b => b.Kickstand != null)
                    .OrderByDescending(b => b.Id)
                    .Skip((page - 1) * ServiceConstants.BikeListingPageSize)
                    .Take(ServiceConstants.BikeListingPageSize)
                    .ProjectTo<BikeListingServiceModel>()
                    .ToListAsync();

        public async Task CreateAsync(
            Make make,
            string model,
            decimal price,
            string imageUrl,
            int quantity,
            int frameSize,
            string wheelesMake,
            string forkMake,
            string tiresMake,
            string shiftersMake,
            string frontDerailleur,
            string rearDerailleur,
            string chain,
            string saddle,
            string handlebar,
            string brakes,
            string color,
            string brakeLevers,
            string batteryMake,
            int? batteryPower,
            string barTape,
            string rearShockMake,
            string kickstand,
            string userId)
        {
            var bike = new Bike
            {
                Make = make,
                Model = model,
                Price = price,
                ImageUrl = imageUrl,
                Quantity = quantity,
                FrameSize = frameSize,
                WheelesMake = wheelesMake,
                ForkMake = forkMake,
                TiresMake = tiresMake,
                ShiftersMake = shiftersMake,
                FrontDerailleur = frontDerailleur,
                RearDerailleur = rearDerailleur,
                Chain = chain,
                Saddle = saddle,
                Handlebar = handlebar,
                Brakes = brakes,
                Color = color,
                BrakeLevers = brakeLevers,
                BatteryMake = batteryMake,
                BatteryPower = batteryPower,
                BarTape = barTape,
                RearShockMake = rearShockMake,
                Kickstand = kickstand,
                UserId = userId
            };

            await this.db.AddAsync(bike);

            await this.db.SaveChangesAsync();
        }

        public async Task<BikeDetailsServiceModel> DetailsAsync(int id)
            => await this.db
                    .Bikes
                    .Where(b => b.Id == id)
                    .ProjectTo<BikeDetailsServiceModel>()
                    .FirstOrDefaultAsync();



        public async Task<int> TotalAsync()
            => await this.db.Bikes.CountAsync();

        public async Task<int> TotalRoadAsync()
           => await this.db.Bikes.Where(b => b.BarTape != null).CountAsync();

        public async Task<int> TotalMountainAsync()
        => await this.db.Bikes.Where(b => b.BrakeLevers != null).CountAsync();

        public async Task<int> TotalSuspensionMountainAsync()
        => await this.db.Bikes.Where(b => b.RearShockMake != null).CountAsync();

        public async Task<int> TotalElectricAsync()
        => await this.db.Bikes.Where(b => b.BatteryMake != null).CountAsync();

        public async Task<int> TotalKidsAsync()
        => await this.db.Bikes.Where(b => b.Kickstand != null).CountAsync();

        public async Task<bool> EditAsync(
            int id,
            Make make,
            string model,
            decimal price,
            string imageUrl,
            int quantity,
            int frameSize,
            string wheelesMake,
            string forkMake,
            string tiresMake,
            string shiftersMake,
            string frontDerailleur,
            string rearDerailleur,
            string chain,
            string saddle,
            string handlebar,
            string brakes,
            string color,
            string brakeLevers,
            string batteryMake,
            int? batteryPower,
            string barTape,
            string rearShockMake,
            string kickstand,
            string userId)
        {
            var bike = this.db.Bikes.FirstOrDefault(b => b.Id == id && b.UserId == userId);

            if (bike == null)
            {
                return false;
            }

            bike.Make = make;
            bike.Model = model;
            bike.Price = price;
            bike.ImageUrl = imageUrl;
            bike.Quantity = quantity;
            bike.FrameSize = frameSize;
            bike.WheelesMake = wheelesMake;
            bike.ForkMake = forkMake;
            bike.TiresMake = tiresMake;
            bike.ShiftersMake = shiftersMake;
            bike.FrontDerailleur = frontDerailleur;
            bike.RearDerailleur = rearDerailleur;
            bike.Chain = chain;
            bike.Saddle = saddle;
            bike.Handlebar = handlebar;
            bike.Brakes = brakes;
            bike.Color = color;
            bike.BrakeLevers = brakeLevers;
            bike.BatteryMake = batteryMake;
            bike.BatteryPower = batteryPower;
            bike.BarTape = barTape;
            bike.RearShockMake = rearShockMake;
            bike.Kickstand = kickstand;
            bike.UserId = userId;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(int id, string userId)
            => await this.db.Bikes.AnyAsync(b => b.Id == id && b.UserId == userId);

        public async Task DeleteAsync(int id)
        {
            var bike = this.db.Bikes.Find(id);

            if (bike == null)
            {
                return;
            }

            this.db.Bikes.Remove(bike);

            await this.db.SaveChangesAsync();
        }
    }
}
