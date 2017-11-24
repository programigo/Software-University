namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services;
    using CameraBazaar.Web.Infrastructure.Filters;
    using CameraBazaar.Web.Models.Cameras;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("cameras")]
    public class CamerasController : Controller
    {
        private UserManager<User> userManager;

        private readonly ICameraService cameras;

        public CamerasController(UserManager<User> userManager, ICameraService cameras)
        {
            this.userManager = userManager;
            this.cameras = cameras;
        }

        [MeasureTime]
        [Authorize]
        [Route(nameof(Add))]
        public IActionResult Add() => this.View();

        [Authorize]
        [HttpPost]
        [Route(nameof(Add))]
        public IActionResult Add(CameraFormModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.cameras.Create(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMetering,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Route("")]
        public IActionResult All() => View(this.cameras.All());

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            return this.ViewOrNotFound(this.cameras.Details(id));
        }

        [Authorize]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var cameraExists = this.cameras.Exists(id, this.userManager.GetUserId(User));

            if (!cameraExists)
            {
                return NotFound();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, CameraFormModel cameraModel)
        {
            var updated = this.cameras.Edit(
                id,
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMetering,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
            => View(id);

        [Authorize]
        [Route("destroy/{id}")]
        public IActionResult Destroy(int id)
        {
            this.cameras.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
