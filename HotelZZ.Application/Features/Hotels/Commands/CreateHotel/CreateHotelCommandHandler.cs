using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Interfaces.Services;
using HotelZZ.Application.Common.Models;
using HotelZZ.Domain.Entities;
using MediatR;

namespace HotelZZ.Application.Features.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;
        public CreateHotelCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task<Result> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            if( await _unitOfWork.Hotels.ExistsByNameAsync(request.Name) )
            {
                Result.Failure($"A hotel named {request.Name} already exists");
            }

            var hotel = MapToHotel(request);

            if(request.Image is not null)
            {
                using var stream = request.Image.OpenReadStream();

                var uploadResult = await _imageService.UploadAsync(
                    stream,
                    request.Image.FileName,
                    folderName:"hotels",
                    cancellationToken);

                hotel.ImageUrl = uploadResult.Value.Url;
                hotel.Identifier = uploadResult.Value.Identifier;
            }

            await _unitOfWork.Hotels.CreateAsync(hotel);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        private static Hotel MapToHotel(CreateHotelCommand command)
        {
            return new Hotel
            {
                Name = command.Name,
                Description = command.Description,
                Address = command.Address,
                City = command.City,
                Country = command.Country,
            };
        }
    }
}