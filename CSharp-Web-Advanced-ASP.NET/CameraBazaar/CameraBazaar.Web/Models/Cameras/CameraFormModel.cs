﻿namespace CameraBazaar.Web.Models.Cameras
{
    using CameraBazaar.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CameraFormModel
    {
        public CameraMake Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Display(Name = "Minimum Shutter Speed")]
        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Maximum Shutter Speed")]
        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Display(Name = "Minimum ISO")]
        public MinISO MinISO { get; set; }

        [Display(Name = "Maximum ISO")]
        [Range(200, 409600)]
        public int MaxISO { get; set; }

        [Display(Name = "Full Frame")]
        public bool IsFullFrame { get; set; }

        [Required]
        [StringLength(15)]
        public string VideoResolution { get; set; }

        public IEnumerable<LightMetering> LightMetering { get; set; }

        [Required]
        [MaxLength(6000)]
        public string Description { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string ImageUrl { get; set; }
    }
}
