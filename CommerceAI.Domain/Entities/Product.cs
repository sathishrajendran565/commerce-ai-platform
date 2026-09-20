using CommerceAI.Domain.ValueObjects;

namespace CommerceAI.Domain.Entities;

public sealed class Product
{
    private Product()
    {
    }

    private Product(
        ProductId id,
        string sku,
        string name,
        string description,
        Money price)
    {
        Id = id;
        Sku = sku;
        Name = name;
        Description = description;
        Price = price;
        IsActive = true;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public ProductId Id { get; private set; }

    public string Sku { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public Money Price { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    public static Product Create(
        string sku,
        string name,
        string description,
        Money price)
    {
        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU is required.", nameof(sku));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException(
                "Product description is required.",
                nameof(description));

        return new Product(
            ProductId.New(),
            sku.Trim(),
            name.Trim(),
            description.Trim(),
            price);
    }

    public void UpdatePrice(Money newPrice)
    {
        Price = newPrice;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}