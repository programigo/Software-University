using System.ComponentModel.DataAnnotations;

namespace BikeMania.Data.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public BikeType Type { get; set; }

        public Make Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Range(0, 50)]
        public int Quantity { get; set; }

        [Range(450, 560)]
        public int FrameSize { get; set; }

        [MinLength(5)]
        [MaxLength(40)]
        public string WheelesMake { get; set; }

        [MinLength(5)]
        [MaxLength(40)]
        public string ForkMake { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string TiresMake { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string ShiftersMake { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string FrontDerailleur { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
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

        //For Mountain Bike
        [MinLength(3)]
        [MaxLength(30)]
        public string BrakeLevers { get; set; }

        //For Electric Bike
        [MinLength(3)]
        [MaxLength(40)]
        public string BatteryMake { get; set; }

        //For Electric Bike
        [Range(110, 1500)]
        public int BatteryPower { get; set; }

        //For Road Bike
        [MinLength(3)]
        [MaxLength(30)]
        public string BarTape { get; set; }

        //For Suspension Mountain Bike
        [MinLength(3)]
        [MaxLength(50)]
        public string RearShockMake { get; set; }

        //For Kids Bike
        [MinLength(3)]
        [MaxLength(20)]
        public string Kickstand { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
