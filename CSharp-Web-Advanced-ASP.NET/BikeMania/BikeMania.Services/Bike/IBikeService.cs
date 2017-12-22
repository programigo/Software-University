namespace BikeMania.Services.Bike
{
    using Bike.Models;
    using Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBikeService
    {
        Task<IEnumerable<BikeListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<int> TotalRoadAsync();

        Task<int> TotalMountainAsync();

        Task<int> TotalSuspensionMountainAsync();

        Task<int> TotalElectricAsync();

        Task<int> TotalKidsAsync();

        Task CreateAsync(
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
            string userId);

        Task<bool> EditAsync(
            int id,
            Make make,
            string model,
            decimal price,
            string imageUrl,
            int quantity,
            int frameSize,
            string WheelesMake,
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
            string userId);

        Task<bool> ExistsAsync(int id, string userId);

        Task DeleteAsync(int id);

        Task<BikeDetailsServiceModel> DetailsAsync(int id);

        Task<IEnumerable<BikeListingServiceModel>> RoadAsync(int page = 1);

        Task<IEnumerable<BikeListingServiceModel>> MountainAsync(int page = 1);

        Task<IEnumerable<BikeListingServiceModel>> SuspensionMountainAsync(int page = 1);

        Task<IEnumerable<BikeListingServiceModel>> ElectricAsync(int page = 1);

        Task<IEnumerable<BikeListingServiceModel>> KidsAsync(int page = 1);
    }
}
