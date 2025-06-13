using BuberDinner.Domain.DinnerAggregate.Enums;
using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.Dinner.Entities;
using pokemon_api.Domain.Dinner.ValueObjects;
using pokemon_api.Domain.Host.ValueObjects;
using pokemon_api.Domain.User.ValueObjects;

namespace pokemon_api.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; }
    public string Description { get; }

    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }

    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public DinnerStatus Status { get; } // Upcoming, InProgress, Ended, Cancelled

    public bool IsPublic { get; }
    public int MaxGuests { get; }

    public ValueObject.Price Price { get; }
    public HostId HostId { get; }
    public UserId MenuId { get; }

    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations;

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        ValueObject.Price price,
        HostId hostId,
        UserId menuId,
        string imageUrl,
        Location location)
    : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        ValueObject.Price price,
        HostId hostId,
        UserId menuId,
        string imageUrl,
        Location location)
    {
        return new(DinnerId.CreateUnique(), name, description, startDateTime, endDateTime, DateTime.UtcNow, DateTime.UtcNow, DinnerStatus.Upcoming, isPublic, maxGuests, price, hostId, menuId, imageUrl, location);
    }
}
