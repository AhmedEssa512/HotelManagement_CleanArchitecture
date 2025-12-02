using HotelZZ.Application.Common.Files;
using HotelZZ.Application.Common.Models;
using MediatR;

namespace HotelZZ.Application.Features.Rooms.Commands.CreateRoom
{
    public record CreateRoomCommand
    (
        string RoomNumber,
        int Capacity,
        string Description,
        decimal PricePerNight,
        int HotelId,
        int RoomTypeId,
        List<int>? AmenityIds,
        List<IImage>? Images

    ) : IRequest<Result>;
        
    
}