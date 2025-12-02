using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.Amenities.DTOs;
using MediatR;

namespace HotelZZ.Application.Features.Amenities.Queries.GetById
{
    public class GetAmenityByIdHandler : IRequestHandler<GetAmenityByIdQuery, Result<AmenityDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAmenityByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<AmenityDto>> Handle(GetAmenityByIdQuery request, CancellationToken cancellationToken)
        {
            var amenity = await _unitOfWork.Amenities.GetByIdAsync(request.Id);

            if (amenity is null)
                return Result<AmenityDto>.Failure("Amenity not found.");

            var dto = new AmenityDto(
                amenity.Id,
                amenity.Name
            );

            return Result<AmenityDto>.Success(dto);
        }
    }
}