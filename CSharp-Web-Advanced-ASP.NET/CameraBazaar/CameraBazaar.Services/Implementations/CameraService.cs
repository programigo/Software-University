namespace CameraBazaar.Services.Implementations
{
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CameraModel> All()
        {
            return this.db
                .Cameras
                .Select(c => new CameraModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity
                })
                .ToList();
        }

        public void Create(CameraMake make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed, MinISO minISO, int maxISO, bool isFullFrame, string videoResolution, IEnumerable<LightMetering> lightmeterings, string description, string imageUrl, string userId)
        {
            var camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MaxISO = maxISO,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LightMetering = (LightMetering)lightmeterings.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(camera);

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var camera = this.db.Cameras.Find(id);

            if (camera == null)
            {
                return;
            }

            this.db.Cameras.Remove(camera);

            this.db.SaveChanges();
        }

        public CameraDetailsModel Details(int id)
        {
            return this.db
                .Cameras
                .Where(c => c.Id == id)
                .Select(c => new CameraDetailsModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    MinShutterSpeed = c.MinShutterSpeed,
                    MaxShutterSpeed = c.MaxShutterSpeed,
                    MinISO = c.MinISO,
                    MaxISO = c.MaxISO,
                    IsFullFrame = c.IsFullFrame,
                    VideoResolution = c.VideoResolution,
                    LightMetering = c.LightMetering,
                    Description = c.Description,
                    User = c.User
                })
                .FirstOrDefault();
        }

        public bool Edit(
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
            string userId
            )
        {
            var camera = this.db
                .Cameras
                .FirstOrDefault(c => c.Id == id && c.UserId == userId);

            if (camera == null)
            {
                return false;
            }

            camera.Make = make;
            camera.Model = model;
            camera.Price = price;
            camera.Quantity = quantity;
            camera.MinShutterSpeed = minShutterSpeed;
            camera.MaxShutterSpeed = maxShutterSpeed;
            camera.MinISO = minISO;
            camera.MaxISO = maxISO;
            camera.IsFullFrame = isFullFrame;
            camera.VideoResolution = videoResolution;
            camera.LightMetering = (LightMetering)lightmeterings.Cast<int>().Sum();
            camera.Description = description;
            camera.ImageUrl = imageUrl;
            camera.UserId = userId;

            this.db.SaveChanges();

            return true;
        }

        public bool Exists(int id, string userId)
            => this.db.Cameras.Any(c => c.Id == id && c.UserId == userId);
    }
}
