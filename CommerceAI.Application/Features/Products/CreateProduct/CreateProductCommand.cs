using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceAI.Application.Features.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Sku,
    string Name,
    string Description,
    decimal Price,
    string Currency);
