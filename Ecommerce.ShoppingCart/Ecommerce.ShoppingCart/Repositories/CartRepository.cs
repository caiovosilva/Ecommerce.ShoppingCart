using Ecommerce.ShoppingCart.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Ecommerce.ShoppingCart.Repositories;

public class CartRepository(IConnectionMultiplexer redis) : ICartRepository
{
    public async Task<CartModel?> GetCartAsync(Guid cartId)
    {
        var db = redis.GetDatabase();
        var cartData = await db.StringGetAsync(cartId.ToString());

        return string.IsNullOrEmpty(cartData) 
            ? null 
            : JsonConvert.DeserializeObject<CartModel>(cartData!);
    }

    public async Task UpdateCartAsync(CartModel cart)
    {
        var db = redis.GetDatabase();
        var serializedCart = JsonConvert.SerializeObject(cart);
        await db.StringSetAsync(cart.CartId.ToString(), serializedCart);
    }
}