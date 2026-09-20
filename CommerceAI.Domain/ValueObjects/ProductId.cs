using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceAI.Domain.ValueObjects;

public readonly record struct ProductId(Guid Value)
{
    public static ProductId New() => new(Guid.NewGuid());
}
