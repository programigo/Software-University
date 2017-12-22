namespace BikeMania.Services.ShoppingCart
{
    using Data.Models;
    using System.Collections.Generic;

    public interface IShoppingCartManager
    {
        void AddToCart(string id, int productId);

        void RemoveFromCart(string id, int productId);

        void UpdateQuantity(string id, int productId, int quantity);

        IEnumerable<CartItem> GetItems(string id);

        void Clear(string id);

        ShoppingCart GetShoppingCart(string id);
    }
}
