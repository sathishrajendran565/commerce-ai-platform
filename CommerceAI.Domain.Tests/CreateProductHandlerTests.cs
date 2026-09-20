using CommerceAI.Application.Abstractions;
using CommerceAI.Application.Features.Products.CreateProduct;
using CommerceAI.Domain.Entities;

namespace CommerceAI.Application.Tests;

public class CreateProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateAndPersistProduct()
    {
        // Arrange
        var repository = new FakeProductRepository();

        var handler = new CreateProductHandler(repository);

        var command = new CreateProductCommand(
            "SHOE-001",
            "Running Shoe",
            "Lightweight running shoe",
            99.99m,
            "EUR");

        // Act
        var result = await handler.Handle(command);

        // Assert
        Assert.NotEqual(default, result.ProductId);
        Assert.NotNull(repository.SavedProduct);
        Assert.Equal("SHOE-001", repository.SavedProduct!.Sku);
        Assert.Equal("Running Shoe", repository.SavedProduct.Name);
        Assert.Equal(99.99m, repository.SavedProduct.Price.Amount);
        Assert.Equal("EUR", repository.SavedProduct.Price.Currency);
    }

    private sealed class FakeProductRepository : IProductRepository
    {
        public Product? SavedProduct { get; private set; }

        public Task AddAsync(
            Product product,
            CancellationToken cancellationToken = default)
        {
            SavedProduct = product;

            return Task.CompletedTask;
        }
    }
}