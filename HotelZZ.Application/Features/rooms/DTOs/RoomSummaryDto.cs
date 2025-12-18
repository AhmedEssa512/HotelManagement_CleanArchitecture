using HotelZZ.Domain.Entities.Enums;

namespace HotelZZ.Application.Features.rooms.DTOs
{
    public record RoomSummaryDto
    (
        int Id,
        string RoomNumber,
        int Capacity,
        decimal PricePerNight,
        RoomStatus Status
    );
}