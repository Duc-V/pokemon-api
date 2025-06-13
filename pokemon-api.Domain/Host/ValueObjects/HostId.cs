﻿using pokemon_api.Domain.Common.Models;

namespace pokemon_api.Domain.Host.ValueObjects;
public sealed class HostId : ValueObject
{
    public string Value { get; }

    private HostId(string value)
    {
        Value = value;
    }

    //public static HostId CreateUnique()
    //{
    //    return new(Guid.NewGuid());
    //}

    public static HostId Create(string id)
    {
        return new(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
