namespace BikeMania.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
