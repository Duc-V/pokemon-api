using BuberDinner.Domain.DinnerAggregate.Enums;
using pokemon_api.Domain.Bill.ValueObjects;
using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.Dinner.ValueObjects;
using pokemon_api.Domain.Guest.ValueObjects;

namespace pokemon_api.Domain.Dinner.Entities;
public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; set; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(ReservationId reservationId, int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId, DateTime arrivalDateTime, DateTime createdDateTime, DateTime updatedDateTime)
        : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(int guestCount, GuestId guestId, DateTime arrivalDateTime)
    {
        return new(ReservationId.CreateUnique(), guestCount, ReservationStatus.PendingGuestConfirmation, guestId, BillId.CreateUnique(), arrivalDateTime, DateTime.UtcNow, DateTime.UtcNow);
    }
}
