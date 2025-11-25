using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities.Enums;

namespace HotelZZ.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int BookingId { get; set; }
        public Booking Booking { get; set; } = default!;

        public int HotelId { get; set; }   
        public Hotel Hotel { get; set; } = default!;

        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = default!;
        public PaymentStatus Status { get; private set; } = PaymentStatus.Pending;
        public string PaymentMethod { get; private set; } = default!;
        public string? ProviderReference { get; private set; }

        public string UserId { get; private set; } = default!;
        public UserProfile User { get; private set; } = default!;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; private set; }

        private Payment() { }

        public Payment(int bookingId, string userId,int hotelId,decimal amount, string currency, string paymentMethod)
        {
            if (amount < 0)
                throw new Exception("Amount cannot be negative.");
            if (string.IsNullOrWhiteSpace(currency))
                throw new Exception("Currency is required.");
            if (string.IsNullOrWhiteSpace(paymentMethod))
                throw new Exception("Payment method is required.");

            BookingId = bookingId;
            Amount = amount;
            Currency = currency;
            PaymentMethod = paymentMethod;
            Status = PaymentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            HotelId = hotelId;
            UserId = userId;
        }

        // Domain behaviors
        public void MarkAsPaid(string providerReference)
        {
            if (Status == PaymentStatus.Paid)
                return;

            Status = PaymentStatus.Paid;
            ProviderReference = providerReference;
            CompletedAt = DateTime.UtcNow;
        }

        public void MarkAsFailed(string? providerReference = null)
        {
            Status = PaymentStatus.Failed;
            ProviderReference = providerReference;
            CompletedAt = DateTime.UtcNow;
        }

        public void Refund(string providerReference)
        {
            if (Status != PaymentStatus.Paid)
                throw new Exception("Only paid payments can be refunded.");

            Status = PaymentStatus.Refunded;
            ProviderReference = providerReference;
            CompletedAt = DateTime.UtcNow;
        }
    }
}