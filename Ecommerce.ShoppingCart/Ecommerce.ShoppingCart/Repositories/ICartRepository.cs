using Ecommerce.ShoppingCart.Models;

namespace Ecommerce.ShoppingCart.Repositories;

public interface ICartRepository
{
    Task<CartModel?> GetCartAsync(Guid cartId);
    Task UpdateCartAsync(CartModel cart);
}