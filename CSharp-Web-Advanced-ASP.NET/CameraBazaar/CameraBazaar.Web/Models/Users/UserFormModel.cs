using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Web.Models.Users
{
    public class UserFormModel
    {
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string NewPassword { get; set; }

        [Display(Name = "Phone")]
        public string Phonenumber { get; set; }

        [Required]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        public bool IsCurrentlyLogged { get; set; }
    }
}
