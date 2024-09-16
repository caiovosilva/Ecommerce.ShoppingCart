using Ecommerce.ShoppingCart.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Ecommerce.ShoppingCart.Cache;

public class RedisCacheService(IConnectionMultiplexer redis) : IRedisCacheService
{
    private readonly IDatabase _database = redis.GetDatabase();

    public async Task<Cart?> GetCachedCartAsync(Guid cartId)
    {
        var cartData = await _database.StringGetAsync(cartId.ToString());
        return string.IsNullOrEmpty(cartData) ? null : JsonConvert.DeserializeObject<Cart>(cartData);
    }

    public async Task SetCacheCartAsync(Cart cart)
    {
        var cartData = JsonConvert.SerializeObject(cart);
        await _database.StringSetAsync(cart.Id.ToString(), cartData);
    }

    public async Task ClearCacheCartAsync(Guid cartId)
    {
        await _database.KeyDeleteAsync(cartId.ToString());
    }
}