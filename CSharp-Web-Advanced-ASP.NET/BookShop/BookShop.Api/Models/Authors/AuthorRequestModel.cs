namespace BookShop.Api.Models.Authors
{
    using Data;
    using System.ComponentModel.DataAnnotations;

    public class AuthorRequestModel
    {
        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLength)]
        public string LastName { get; set; }
    }
}
