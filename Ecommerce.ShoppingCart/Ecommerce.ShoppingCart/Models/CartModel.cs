namespace Ecommerce.ShoppingCart.Models;

public record CartModel
{
    public Guid CartId { get; init; }
    public List<CartItem> Items { get; init; } = new();
    public DateTime LastUpdated { get; init; }

    public decimal TotalPrice => Items.Sum(item => item.Total);
}