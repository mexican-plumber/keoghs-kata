namespace Keoghs.Kata.Application.Pricing;

public interface IPricingService
{
    decimal GetPrice(string sku, int quantity);
}