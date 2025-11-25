using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelZZ.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>

    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            builder
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Hotel)
                .WithMany(h => h.Payments)
                .HasForeignKey(p => p.HotelId);

            builder.HasOne(p => p.Booking)         
                .WithOne(b => b.Payment)       
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}