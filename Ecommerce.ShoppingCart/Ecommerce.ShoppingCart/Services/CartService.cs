using Ecommerce.ShoppingCart.Repositories;
using Ecommerce.ShoppingCart.Cache;
using Ecommerce.ShoppingCart.Models;

namespace Ecommerce.ShoppingCart.Services;

public class CartService(ICartRepository repository, ILogger<CartService> logger) : ICartService
{
    public async Task<CartModel> GetCartAsync(Guid cartId)
    {
        return await repository.GetCartAsync(cartId) ?? new CartModel { CartId = cartId, LastUpdated = DateTime.UtcNow };
    }

    public async Task AddItemToCartAsync(Guid cartId, CartItem item)
    {
        var cart = await GetCartAsync(cartId);
        var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
        
        if (existingItem != null)
        {
            var updatedItem = existingItem with { Quantity = existingItem.Quantity + item.Quantity };
            cart.Items.Remove(existingItem);
            cart.Items.Add(updatedItem);
        }
        else
        {
            cart.Items.Add(item);
        }
        
        cart = cart with { LastUpdated = DateTime.UtcNow };
        await repository.UpdateCartAsync(cart);
        logger.LogInformation("Item added to cart: {@CartId}", cartId);
    }

    public async Task RemoveItemFromCartAsync(Guid cartId, Guid productId)
    {
        var cart = await GetCartAsync(cartId);
        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        
        if (item != null)
        {
            cart.Items.Remove(item);
            cart = cart with { LastUpdated = DateTime.UtcNow };
            await repository.UpdateCartAsync(cart);
            logger.LogInformation("Item removed from cart: {@CartId}", cartId);
        }
    }

    public async Task ClearCartAsync(Guid cartId)
    {
        var cart = await GetCartAsync(cartId);
        cart = cart with { Items = new List<CartItem>(), LastUpdated = DateTime.UtcNow };
        await repository.UpdateCartAsync(cart);
        logger.LogInformation("Cart cleared: {@CartId}", cartId);
    }
}