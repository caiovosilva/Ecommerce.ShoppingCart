using Ecommerce.ShoppingCart.Models;

namespace Ecommerce.ShoppingCart.Cache;

public interface IRedisCacheService
{
    Task<Cart?> GetCachedCartAsync(Guid cartId);
    Task SetCacheCartAsync(Cart cart);
    Task ClearCacheCartAsync(Guid cartId);
}