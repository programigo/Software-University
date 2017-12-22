namespace BikeMania.Web.Areas.Products.Models.Bikes
{
    using BikeMania.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class BikeFormModel
    {
        public Make Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }

        [Range(0, 50)]
        public int Quantity { get; set; }

        [Range(450, 560)]
        [Display(Name = "Frame Size")]
        public int FrameSize { get; set; }

        [MinLength(5)]
        [MaxLength(40)]
        [Display(Name = "Wheeles Make")]
        public string WheelesMake { get; set; }

        [MinLength(5)]
        [MaxLength(40)]
        [Display(Name = "Fork Make")]
        public string ForkMake { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Tires Make")]
        public string TiresMake { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Shifters Make")]
        public string ShiftersMake { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Front Derailleur")]
        public string FrontDerailleur { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Rear Derailleur")]
        public string RearDerailleur { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string Chain { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string Saddle { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string Handlebar { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string Brakes { get; set; }

        [Required]
        public string Color { get; set; }

        [MaxLength(30)]
        [Display(Name = "Brake Levers")]
        public string BrakeLevers { get; set; }

        [MaxLength(40)]
        [Display(Name = "Battery Make")]
        public string BatteryMake { get; set; }

        [Display(Name = "Battery Power")]
        public int? BatteryPower { get; set; }

        [MaxLength(30)]
        [Display(Name = "Bar Tape")]
        public string BarTape { get; set; }

        [MaxLength(50)]
        [Display(Name = "Rear Shock Make")]
        public string RearShockMake { get; set; }

        [MaxLength(20)]
        public string Kickstand { get; set; }
    }
}
