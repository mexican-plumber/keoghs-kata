namespace Keoghs.Kata.Application;

public interface IShoppingBasket
{
    void AddItem(string sku, int quantity);
    decimal CalculateTotal();
}