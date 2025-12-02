using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.RoomTypes.DTOs;
using MediatR;

namespace HotelZZ.Application.Features.RoomTypes.Queries.GetById
{
    public class GetRoomTypeByIdHandler : IRequestHandler<GetRoomTypeByIdQuery, Result<RoomTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoomTypeByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<RoomTypeDto>> Handle(GetRoomTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var roomType = await _unitOfWork.RoomTypes.GetByIdAsync(request.Id);

            if(roomType is null)
            {
                return Result<RoomTypeDto>.Failure("Room type not found.");
            }

            var dto = new RoomTypeDto(
                roomType.Id,
                roomType.Name
            );

            return Result<RoomTypeDto>.Success(dto);
        }
    }
}