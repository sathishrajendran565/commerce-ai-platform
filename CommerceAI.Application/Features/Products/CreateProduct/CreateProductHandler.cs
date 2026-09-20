using System;
using System.Collections.Generic;
using System.Text;

 

using CommerceAI.Application.Abstractions;
using CommerceAI.Domain.Entities;
using CommerceAI.Domain.ValueObjects;
using global::CommerceAI.Application.Abstractions;

namespace CommerceAI.Application.Features.Products.CreateProduct;

public sealed class CreateProductHandler(
    IProductRepository productRepository)
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken = default)
    {
        var price = new Money(
            command.Price,
            command.Currency);

        var product = Product.Create(
            command.Sku,
            command.Name,
            command.Description,
            price);

        await productRepository.AddAsync(
            product,
            cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
