using CommerceAI.Domain.Entities;
using CommerceAI.Domain.ValueObjects;

namespace CommerceAI.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void Create_ShouldCreateActiveProduct()
    {
        // Arrange
        var price = new Money(99.99m, "EUR");

        // Act
        var product = Product.Create(
            "SHOE-001",
            "Running Shoe",
            "Lightweight running shoe",
            price);

        // Assert
        Assert.NotEqual(default, product.Id);
        Assert.Equal("SHOE-001", product.Sku);
        Assert.Equal("Running Shoe", product.Name);
        Assert.Equal(99.99m, product.Price.Amount);
        Assert.Equal("EUR", product.Price.Currency);
        Assert.True(product.IsActive);
    }

    [Fact]
    public void Create_ShouldRejectEmptySku()
    {
        // Arrange
        var price = new Money(99.99m, "EUR");

        // Act
        var action = () => Product.Create(
            "",
            "Running Shoe",
            "Lightweight running shoe",
            price);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Deactivate_ShouldMakeProductInactive()
    {
        // Arrange
        var product = Product.Create(
            "SHOE-001",
            "Running Shoe",
            "Lightweight running shoe",
            new Money(99.99m, "EUR"));

        // Act
        product.Deactivate();

        // Assert
        Assert.False(product.IsActive);
    }
}