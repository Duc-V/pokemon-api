using pokemon_api.Domain.Bill.ValueObjects;
using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.Dinner.ValueObjects;
using pokemon_api.Domain.Guest.ValueObjects;
using pokemon_api.Domain.Host.ValueObjects;

namespace pokemon_api.Domain.Bill;
public sealed class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public ValueObject.Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(BillId billId, DinnerId dinnerId, GuestId guestId, HostId hostId, ValueObject.Price price, DateTime createdDateTime, DateTime updatedDateTime)
        : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId, ValueObject.Price price)
    {
        return new(BillId.CreateUnique(), dinnerId, guestId, hostId, price, DateTime.UtcNow, DateTime.UtcNow);
    }
}
