using Keoghs.Kata.Application.Pricing;

namespace Keoghs.Kata.Application;

public class ShoppingBasket : IShoppingBasket
{
    private readonly IPricingService _pricingService;

    //  will internally hold all the items added to basket
    private readonly Dictionary<string, int> _items = new();

    public ShoppingBasket(IPricingService pricingService)
    {
        _pricingService = pricingService;
    }

    public void AddItem(string sku, int quantity)
    {
        if (!_items.ContainsKey(sku))
        {
            _items[sku] = quantity;
        }
        else
        {
            _items[sku] += quantity;
        }
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;

        foreach (var item in _items)
        {
            //  key = sku, value = quantity
            total += CalculateItemTotal(item.Key, item.Value);
        }

        return total;
    }

    private decimal CalculateItemTotal(string sku, int quantity)
    {
        return _pricingService.GetPrice(sku, quantity);
    }

}