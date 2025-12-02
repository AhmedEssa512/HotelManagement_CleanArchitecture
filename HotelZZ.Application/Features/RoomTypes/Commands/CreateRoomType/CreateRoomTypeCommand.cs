using HotelZZ.Application.Common.Models;
using MediatR;

namespace HotelZZ.Application.Features.RoomTypes.Commands.CreateRoomType
{
    public record CreateRoomTypeCommand
    (
        string Name
    ) : IRequest<Result>;
        
    
}