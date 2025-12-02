using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Interfaces.Services;
using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.Rooms.Commands.CreateRoom;
using HotelZZ.Domain.Entities;
using HotelZZ.Domain.Entities.Enums;
using MediatR;

namespace HotelZZ.Application.Features.rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public CreateRoomCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }
        public async Task<Result> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _unitOfWork.Hotels.GetByIdAsync(request.HotelId);
            if (hotel is null) return Result.Failure("Hotel not found.");

            var roomType = await _unitOfWork.RoomTypes.GetByIdAsync(request.RoomTypeId);
            if (roomType is null) return Result.Failure("Room type not found.");

            List<Amenity> amenities = new();
            if (request.AmenityIds != null && request.AmenityIds.Count > 0)
            {
                amenities = await _unitOfWork.Amenities.GetByIdsAsync(request.AmenityIds);
                if (amenities.Count != request.AmenityIds.Count)
                    return Result.Failure("Amenities not found.");
            }

            // Create the Room entity
            var room = new Room
            {
                RoomNumber = request.RoomNumber,
                Capacity = request.Capacity,
                Description = request.Description,
                PricePerNight = request.PricePerNight,
                HotelId = request.HotelId,
                RoomTypeId = request.RoomTypeId,
                Status = RoomStatus.Available,
                Amenities = amenities
            };

            // Upload images (max 5)
            if (request.Images != null && request.Images.Count > 0)
            {
                if (request.Images.Count > 5)
                    return Result.Failure("Maximum 5 images are allowed.");

                foreach (var image in request.Images)
                {
                    var uploadResult = await _imageService.UploadAsync(
                        image.OpenReadStream(),
                        image.FileName,
                        folderName: "rooms",
                        cancellationToken
                    );

                    if (uploadResult.IsFailure)
                        return Result.Failure("uploading failed");

                    room.Images.Add(new RoomImage
                    {
                        ImageUrl = uploadResult.Value.Url,
                        PublicId = uploadResult.Value.Identifier
                        
                    });
                }
            }


            await _unitOfWork.Rooms.CreateAsync(room);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        
    }
}