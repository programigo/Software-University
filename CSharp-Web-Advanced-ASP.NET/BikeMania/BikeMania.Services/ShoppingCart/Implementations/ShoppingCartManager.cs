namespace BikeMania.Services.ShoppingCart.Implementations
{
    using Data.Models;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> carts;

        public ShoppingCartManager()
        {
            this.carts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddToCart(string id, int productId)
        {
            var shoppingCart = this.GetShoppingCart(id);

            shoppingCart.AddToCart(productId);
        }

        public void Clear(string id) => this.GetShoppingCart(id).Clear();

        public IEnumerable<CartItem> GetItems(string id)
        {
            var shoppingCart = this.GetShoppingCart(id);

            return new List<CartItem>(shoppingCart.Items);
        }

        public void RemoveFromCart(string id, int productId)
        {
            var shoppingCart = this.GetShoppingCart(id);

            shoppingCart.RemoveFromCart(productId);
        }

        public void UpdateQuantity(string id, int productId, int quantity)
        {
            var shoppingCart = this.GetShoppingCart(id);

            shoppingCart.UpdateQuantity(productId, quantity);
        }

        public ShoppingCart GetShoppingCart(string id)
            => this.carts.GetOrAdd(id, new ShoppingCart());

    }
}
