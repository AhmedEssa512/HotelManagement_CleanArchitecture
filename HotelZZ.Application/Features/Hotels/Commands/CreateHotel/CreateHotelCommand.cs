using HotelZZ.Application.Common.Files;
using HotelZZ.Application.Common.Models;
using MediatR;

namespace HotelZZ.Application.Features.Hotels.Commands.CreateHotel
{
    public record CreateHotelCommand
    (
        string Name,
        string Description,
        IImage? Image,
        string Address,
        string City,
        string Country

    ) : IRequest<Result>;
        
    
}