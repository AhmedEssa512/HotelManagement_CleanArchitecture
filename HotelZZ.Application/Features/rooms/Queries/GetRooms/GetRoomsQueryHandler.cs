using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.rooms.DTOs;
using MediatR;

namespace HotelZZ.Application.Features.rooms.Queries.GetRooms
{
    public class GetRoomsQueryHandler
        : IRequestHandler<GetRoomsQuery, PaginatedResult<RoomSummaryDto>>
    {
            private readonly IRoomRepository _roomRepository;

            public GetRoomsQueryHandler(IRoomRepository roomRepository)
            {
                _roomRepository = roomRepository;
            }

            public async Task<PaginatedResult<RoomSummaryDto>> Handle(
                GetRoomsQuery request,
                CancellationToken cancellationToken)
            {

                return await _roomRepository.GetRoomsAsync(
                    request.HotelId,
                    request.PageNumber,
                    request.PageSize,
                    request.Status
                );
            }
        }
    }