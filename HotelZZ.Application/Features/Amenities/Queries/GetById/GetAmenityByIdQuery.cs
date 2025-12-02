using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.Amenities.DTOs;
using MediatR;

namespace HotelZZ.Application.Features.Amenities.Queries.GetById
{
    public record GetAmenityByIdQuery
    (
        int Id
    ) : IRequest<Result<AmenityDto>>;
}