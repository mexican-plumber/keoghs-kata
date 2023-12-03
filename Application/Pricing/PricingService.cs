namespace Keoghs.Kata.Application.Pricing;

public class PricingService : IPricingService
{
    private static readonly Dictionary<string, decimal> _products = new()
    {
        { "A", 10 },
        { "B", 15 },
        { "C", 40 },
        { "D", 55 }
    };

    //  For simplicity each sku can only have one pricing rule and pricing methods made static to facilitate direct mapping
    private readonly Dictionary<string, Func<string, int, decimal>> _rules = new()
    {
        { "B", ThreeUnitsForForty },
        { "D", TwoUnitsTwentyFivePercentOff }
    };

    public decimal GetPrice(string sku, int quantity)
    {
        _rules.TryGetValue(sku, out var rule);

        return rule?.Invoke(sku, quantity) ?? BasicPricing(sku, quantity);
    }

    private static decimal GetUnitPrice(string sku)
    {
        _products.TryGetValue(sku, out var price);

        return price;
    }

    private decimal BasicPricing(string sku, int quantity)
    {
        var unitPrice = GetUnitPrice(sku);

        return quantity * unitPrice;
    }

    private static decimal ThreeUnitsForForty(string sku, int quantity)
    {
        var totalPrice = 0m;
        var unitPrice = GetUnitPrice(sku);
        var sets = quantity / 3;
        var remainder = quantity % 3;
        var fixedPricePerSet = 40;

        totalPrice += sets * fixedPricePerSet;
        totalPrice += remainder * unitPrice;

        return totalPrice;
    }

    private static decimal TwoUnitsTwentyFivePercentOff(string sku, int quantity)
    {
        var totalPrice = 0m;
        var unitPrice = GetUnitPrice(sku);
        var sets = quantity / 2;
        var remainder = quantity % 2;
        var quantityPerSet = 2;
        var discountPerSet = 0.75m;

        totalPrice += (sets * unitPrice * quantityPerSet) * discountPerSet;
        totalPrice += remainder * unitPrice;

        return totalPrice;
    }
}