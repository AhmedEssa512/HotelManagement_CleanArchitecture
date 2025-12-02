using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Models;
using HotelZZ.Domain.Entities;
using MediatR;

namespace HotelZZ.Application.Features.RoomTypes.Commands.CreateRoomType
{
    public class CreateRoomTypeHandler : IRequestHandler<CreateRoomTypeCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = new RoomType{
                Name = request.Name
            };

            await _unitOfWork.RoomTypes.CreateAsync(roomType);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}