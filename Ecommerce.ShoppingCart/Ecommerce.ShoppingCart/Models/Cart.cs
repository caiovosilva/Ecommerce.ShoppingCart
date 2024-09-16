namespace Ecommerce.ShoppingCart.Models;

public record Cart(Guid Id, List<CartItem> Items);

public record CartItem
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }

    public decimal Total => Price * Quantity;
}
