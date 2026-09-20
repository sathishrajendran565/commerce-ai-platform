using System;
using System.Collections.Generic;
using System.Text;

using CommerceAI.Domain.ValueObjects;

namespace CommerceAI.Application.Features.Products.CreateProduct;

public sealed record CreateProductResult(
    ProductId ProductId);
