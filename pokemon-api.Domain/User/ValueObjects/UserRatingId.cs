using pokemon_api.Domain.Common.Models;

namespace pokemon_api.Domain.User.ValueObjects;
public sealed class UserRatingId : ValueObject
{
    public Guid Value { get; }

    private UserRatingId(Guid value)
    {
        Value = value;
    }

    public static UserRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
