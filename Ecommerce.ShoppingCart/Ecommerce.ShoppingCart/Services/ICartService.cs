using Ecommerce.ShoppingCart.Models;

namespace Ecommerce.ShoppingCart.Services;

public interface ICartService
{
    Task<CartModel> GetCartAsync(Guid cartId);
    Task AddItemToCartAsync(Guid cartId, CartItem item);
    Task RemoveItemFromCartAsync(Guid cartId, Guid productId);
    Task ClearCartAsync(Guid cartId);
}