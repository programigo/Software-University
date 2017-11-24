namespace CameraBazaar.Web.Models.Cameras
{
    using CameraBazaar.Services.Models;
    using System.Collections.Generic;

    public class AllCamerasModel
    {
        public IEnumerable<CameraModel> Cameras { get; set; }
    }
}