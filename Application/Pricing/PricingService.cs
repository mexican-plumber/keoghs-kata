namespace Keoghs.Kata.Application.Pricing;

public class PricingService : IPricingService
{
    private readonly Dictionary<string, decimal> _products = new()
    {
        { "A", 10 },
        { "B", 15 },
        { "C", 40 },
        { "D", 55 }
    };

    public decimal GetPrice(string sku, int quantity)
    {
        _products.TryGetValue(sku, out var unitPrice);

        return quantity * unitPrice;
    }
}