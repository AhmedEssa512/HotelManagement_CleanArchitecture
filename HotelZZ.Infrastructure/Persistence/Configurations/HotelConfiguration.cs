using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelZZ.Infrastructure.Persistence.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(h => h.Address)
                .HasMaxLength(300);

            builder
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasMany(h => h.Reviews)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

            builder
                .HasMany(h => h.Bookings)
                .WithOne(b => b.Hotel)
                .HasForeignKey(b => b.HotelId);

            builder
                .HasMany(h => h.Payments)
                .WithOne(p => p.Hotel)
                .HasForeignKey(p => p.HotelId);
        }
    }
}