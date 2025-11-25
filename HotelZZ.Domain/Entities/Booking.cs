using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities.Enums;

namespace HotelZZ.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;

        public string UserId { get; private set; } = default!;
        public UserProfile User { get; private set; } = default!;

        // Stay dates
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }

        public decimal TotalPrice { get; private set; }

        public BookingStatus Status { get; private set; } = BookingStatus.Pending;
        public int HotelId { get; private set; }      // Add this
        public Hotel Hotel { get; private set; } = default!;

        public Payment? Payment { get; private set; }

        private Booking() { }

        public Booking(int roomId, string userId, DateTime checkIn, DateTime checkOut, decimal totalPrice, int hotelId)
        {
            if (checkIn >= checkOut)
                throw new Exception("Check-out must be after check-in.");
            if (totalPrice < 0)
                throw new Exception("Total price cannot be negative.");
            if (string.IsNullOrWhiteSpace(userId))
                throw new Exception("UserId is required.");

            RoomId = roomId;
            UserId = userId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPrice = totalPrice;
            Status = BookingStatus.Pending;
            HotelId = hotelId;
        }

        // Domain behaviors
        public void Confirm()
        {
            if (Status != BookingStatus.Pending)
                throw new Exception("Only pending bookings can be confirmed.");
            Status = BookingStatus.Confirmed;
        }

        public void CheckInGuest()
        {
            if (Status != BookingStatus.Confirmed)
                throw new Exception("Only confirmed bookings can be checked in.");
            Status = BookingStatus.CheckedIn;
        }

        public void CheckOutGuest()
        {
            if (Status != BookingStatus.CheckedIn)
                throw new Exception("Only checked-in bookings can be checked out.");
            Status = BookingStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status == BookingStatus.CheckedOut)
                throw new Exception("Cannot cancel a completed booking.");
            Status = BookingStatus.Cancelled;
        }

        public void AttachPayment(Payment payment)
        {
            if (Payment != null)
                throw new Exception("Payment already attached.");
            Payment = payment;
        }

    }
}