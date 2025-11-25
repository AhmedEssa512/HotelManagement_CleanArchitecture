using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelZZ.Infrastructure.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.RoomNumber)
                .HasMaxLength(50)
                .IsRequired();


            builder
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(r => r.Images)
                .WithOne(ri => ri.Room)
                .HasForeignKey(ri => ri.RoomId);

            builder.HasMany(r => r.Amenities)
               .WithMany(a => a.Rooms)
               .UsingEntity<Dictionary<string, object>>(
                   "RoomAmenity",
                   j => j.HasOne<Amenity>().WithMany().HasForeignKey("AmenityId"),
                   j => j.HasOne<Room>().WithMany().HasForeignKey("RoomId"),
                   j =>
                   {
                       j.HasKey("RoomId", "AmenityId");
                       j.ToTable("RoomAmenities");
                   });
        }
    }
}