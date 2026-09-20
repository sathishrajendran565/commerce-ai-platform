using System;
using System.Collections.Generic;
using System.Text;

using CommerceAI.Domain.Entities;

namespace CommerceAI.Application.Abstractions;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
}
