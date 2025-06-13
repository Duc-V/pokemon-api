using pokemon_api.Domain.Bill.ValueObjects;
using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.Common.ValueObjects;
using pokemon_api.Domain.Dinner.ValueObjects;
using pokemon_api.Domain.Guest.ValueObjects;
using pokemon_api.Domain.MenuReview.ValueObjects;
using pokemon_api.Domain.User.Entity;
using pokemon_api.Domain.User.ValueObjects;

namespace pokemon_api.Domain.Guest;
public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<UserRating> _ratings = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds;
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds;
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds;
    public IReadOnlyList<BillId> BillIds => _billIds;
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds;
    public IReadOnlyList<UserRating> Ratings => _ratings;
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Guest(GuestId guestId, string firstName, string lastName, string profileImage, AverageRating averageRating, UserId userId, DateTime createdDateTime, DateTime updatedDateTime)
    : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(string firstName, string lastName, string profileImage, AverageRating averageRating, UserId userId)
    {
        return new(GuestId.CreateUnique(), firstName, lastName, profileImage, averageRating, userId, DateTime.UtcNow, DateTime.UtcNow);
    }
}
