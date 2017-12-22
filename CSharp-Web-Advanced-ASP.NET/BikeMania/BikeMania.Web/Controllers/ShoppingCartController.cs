namespace BikeMania.Web.Controllers
{
    using BikeMania.Data;
    using BikeMania.Data.Models;
    using BikeMania.Web.Infrastructure.Extensions;
    using BikeMania.Web.Models.ShoppingCart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.ShoppingCart;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly BikeManiaDbContext db;
        private readonly UserManager<User> userManager;

        public ShoppingCartController(IShoppingCartManager shoppingCartManager, UserManager<User> userManager, BikeManiaDbContext db)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.userManager = userManager;
            this.db = db;
        }

        public IActionResult Items()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemsWithDetails = this.GetCartItems(items);
            
            return View(itemsWithDetails);
        }

        public IActionResult AddToCart(int id)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.AddToCart(shoppingCartId, id);

            return RedirectToAction(nameof(Items));
        }

        public IActionResult RemoveFromCart(int id)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.RemoveFromCart(shoppingCartId, id);

            return RedirectToAction(nameof(Items));
        }

        public IActionResult Update(CartItemViewModel model)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            //this.shoppingCartManager.UpdateQuantity(shoppingCartId, id, quantity);

            return RedirectToAction(nameof(Items));
        }

        [Authorize]
        public IActionResult FinishOrder()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            if (items.Count() == 0)
            {
                return NotFound();
            }

            var itemsWithDetails = this.GetCartItems(items);

            var order = new Order
            {
                UserId = this.userManager.GetUserId(User),
                TotalPrice = itemsWithDetails.Sum(i => i.Price * i.Quantity)
            };

            foreach (var item in itemsWithDetails)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductPrice = item.Price,
                    Quantity = item.Quantity
                });
            }

            this.db.Add(order);

            this.db.SaveChanges();

            this.shoppingCartManager.Clear(shoppingCartId);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private List<CartItemViewModel> GetCartItems(IEnumerable<CartItem> items)
        {
            var itemIds = items.Select(i => i.ProductId);

            var itemsWithDetails = this.db
                .Bikes
                .Where(b => itemIds.Contains(b.Id))
                .Select(b => new CartItemViewModel
                {
                    ProductId = b.Id,
                    Title = b.Make + " " + b.Model,
                    Price = b.Price
                })
                .ToList();

            var itemQuantities = items.ToDictionary(i => i.ProductId, i => i.Quantity);

            itemsWithDetails.ForEach(i => i.Quantity = itemQuantities[i.ProductId]);

            return itemsWithDetails;
        }

        //public IActionResult Update()
        //{
        //    var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
        //    var cartItems = this.shoppingCartManager.GetShoppingCart(shoppingCartId).Items.ToList();
        //    var quantities = cartItems.Select(i => i.Quantity).ToList();
        //
        //    for (int i = 0; i < cartItems.Count(); i++)
        //    {
        //        cartItems[i].Quantity = quantities[i];
        //    }
        //
        //    return RedirectToAction(nameof(Items));
        //}
    }
}
