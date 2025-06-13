﻿using pokemon_api.Domain.Common.Models;

namespace pokemon_api.Domain.Menu.ValueObjects;
public sealed class MenuId : ValueObject
{
    public Guid Value { get; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        // TODO: Enfornce Invariants
        return new(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        // TODO: Enfornce Invariants
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
