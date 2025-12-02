using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Models;
using HotelZZ.Domain.Entities;
using MediatR;

namespace HotelZZ.Application.Features.Amenities.Commands.CreateAmenity
{
    public class CreateAmenityHandler : IRequestHandler<CreateAmenityCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAmenityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateAmenityCommand request, CancellationToken cancellationToken)
        {
            var amenity = new Amenity {
                Name = request.Name
            };

            await _unitOfWork.Amenities.CreateAsync(amenity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}