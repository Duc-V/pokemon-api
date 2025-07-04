﻿using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.Common.ValueObjects;
using pokemon_api.Domain.Dinner.ValueObjects;
using pokemon_api.Domain.Host.ValueObjects;
using pokemon_api.Domain.Menu.ValueObjects;
using pokemon_api.Domain.User.ValueObjects;

namespace pokemon_api.Domain.Host;
public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds;
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds;

    private Host(HostId hostId, string firstName, string lastName, string profileImage, AverageRating averageRating, UserId userId, DateTime createdDateTime, DateTime updatedDateTime)
        : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(HostId hostId, string firstName, string lastName, string profileImage, AverageRating averageRating, UserId userId)
    {
        return new(hostId, firstName, lastName, profileImage, averageRating, userId, DateTime.UtcNow, DateTime.UtcNow);
    }
}
