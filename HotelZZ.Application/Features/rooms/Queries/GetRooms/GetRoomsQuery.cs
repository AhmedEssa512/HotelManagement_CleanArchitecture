using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.rooms.DTOs;
using HotelZZ.Domain.Entities.Enums;
using MediatR;

namespace HotelZZ.Application.Features.rooms.Queries.GetRooms
{
    public record GetRoomsQuery
    (
        int HotelId,
        int PageNumber,
        int PageSize,
        RoomStatus? Status
    ) : IRequest<PaginatedResult<RoomSummaryDto>>;

}