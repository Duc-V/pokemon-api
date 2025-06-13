using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.Common.ValueObjects;
using pokemon_api.Domain.Dinner.ValueObjects;
using pokemon_api.Domain.Guest.ValueObjects;
using pokemon_api.Domain.Host.ValueObjects;
using pokemon_api.Domain.Menu.ValueObjects;
using pokemon_api.Domain.MenuReview.ValueObjects;

namespace pokemon_api.Domain.MenuReview;
public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public Rating Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuReview(MenuReviewId menuReviewId, Rating rating, string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId, DateTime createdDateTime, DateTime updatedDateTime)
    : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview Create(Rating rating, string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId)
    {
        return new(MenuReviewId.CreateUnique(), rating, comment, hostId, menuId, guestId, dinnerId, DateTime.UtcNow, DateTime.UtcNow);
    }
}
