using HotelZZ.Application.Common.Models;
using MediatR;

namespace HotelZZ.Application.Features.Amenities.Commands.CreateAmenity
{
    public record CreateAmenityCommand
    (
        string Name
    ): IRequest<Result>;
}