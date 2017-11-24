namespace CameraBazaar.Services
{
    using CameraBazaar.Services.Models;
    using Data.Models;
    using System.Collections.Generic;

    public interface ICameraService
    {
        IEnumerable<CameraModel> All();

        CameraDetailsModel Details(int id);

        void Create(
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightmeterings,
            string description,
            string imageUrl,
            string userId
            );

        bool Edit(
            int id,
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightmeterings,
            string description,
            string imageUrl,
            string userId);

        bool Exists(int id, string userId);

        void Delete(int id);
    }
}
