using Ecommerce.ShoppingCart.Services;
using Ecommerce.ShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.ShoppingCart.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController(ICartService cartService) : ControllerBase
{
    [HttpGet("{cartId}")]
    public async Task<IActionResult> GetCart(Guid cartId)
    {
        var cart = await cartService.GetCartAsync(cartId);
        return Ok(cart);
    }

    [HttpPost("{cartId}/items")]
    public async Task<IActionResult> AddItemToCart(Guid cartId, [FromBody] CartItem item)
    {
        await cartService.AddItemToCartAsync(cartId, item);
        return NoContent();
    }

    [HttpDelete("{cartId}/items/{productId}")]
    public async Task<IActionResult> RemoveItemFromCart(Guid cartId, Guid productId)
    {
        await cartService.RemoveItemFromCartAsync(cartId, productId);
        return NoContent();
    }

    [HttpDelete("{cartId}/clear")]
    public async Task<IActionResult> ClearCart(Guid cartId)
    {
        await cartService.ClearCartAsync(cartId);
        return NoContent();
    }
}