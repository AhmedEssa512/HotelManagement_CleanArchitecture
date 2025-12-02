

using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.RoomTypes.DTOs;
using MediatR;

namespace HotelZZ.Application.Features.RoomTypes.Queries.GetById
{
    public record GetRoomTypeByIdQuery(int Id) : IRequest<Result<RoomTypeDto>>;
        
}