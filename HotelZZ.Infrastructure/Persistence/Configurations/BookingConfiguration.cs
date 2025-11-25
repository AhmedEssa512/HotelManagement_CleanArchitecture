using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelZZ.Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
           builder.ToTable("Bookings");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.CheckIn).IsRequired();
            builder.Property(b => b.CheckOut).IsRequired();
            builder.Property(b => b.RoomId).IsRequired();
            builder.Property(b => b.HotelId).IsRequired();
            builder.Property(b => b.UserId).IsRequired();

            builder.HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}