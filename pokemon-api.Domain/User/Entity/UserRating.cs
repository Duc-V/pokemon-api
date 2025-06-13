using pokemon_api.Domain.Common.ValueObjects;
using pokemon_api.Domain.Dinner.Entities;
using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.Dinner.ValueObjects;
using pokemon_api.Domain.Host.ValueObjects;
using pokemon_api.Domain.User.ValueObjects;

namespace pokemon_api.Domain.User.Entity;
public sealed class UserRating : Entity<UserRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private UserRating(UserRatingId userRatingId, HostId hostid, DinnerId dinnerId, Rating rating, DateTime createdDateTime, DateTime updatedDateTime)
        : base(userRatingId)
    {
        HostId = hostid;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static UserRating Create(HostId hostId, DinnerId dinnerId, Rating rating)
    {
        return new(UserRatingId.CreateUnique(), hostId, dinnerId, rating, DateTime.UtcNow, DateTime.UtcNow);
    }
}

