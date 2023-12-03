using Keoghs.Kata.Application.Pricing;

namespace Keoghs.Kata.Application.Tests;

public class ShoppingBasketTests
{
    private IShoppingBasket _basket;
    private IPricingService _pricingService;

    //  Note: for simplicity direct object instantiation is used rather than with Moq framework,
    //  which would be my preferred method in a real world production scenario.
    [SetUp]
    public void Setup()
    {
        _pricingService = new PricingService();
        _basket = new ShoppingBasket(_pricingService);
    }

    #region Basic functionality

    [Test]
    public void CanAddItems()
    {
        //  Arrange
        var basket = _basket;

        //  Act
        basket.AddItem("A", 3);
        basket.AddItem("B", 1);

        //  Assert
        Assert.That(basket.CalculateTotal(), Is.GreaterThan(0));
    }

    [Test]
    public void NoItemsYieldZero()
    {
        //  Arrange
        var basket = _basket;

        //  Act

        //  Assert
        Assert.That(basket.CalculateTotal(), Is.EqualTo(0));
    }

    #endregion

    #region Basket totals

    [Test]
    public void OneItemCalculatesPriceCorrectly()
    {
        //  Arrange
        var basket = _basket;

        //  Act
        basket.AddItem("A", 3);

        //  Assert
        Assert.That(basket.CalculateTotal(), Is.EqualTo(30));
    }

    [Test]
    public void MultipleItemsCalculatesPriceCorrectly()
    {
        //  Arrange
        var basket = _basket;

        //  Act
        basket.AddItem("A", 1);
        basket.AddItem("B", 1);
        basket.AddItem("C", 1);
        basket.AddItem("D", 1);

        //  Assert
        Assert.That(basket.CalculateTotal(), Is.EqualTo(120));
    }

    #endregion
}