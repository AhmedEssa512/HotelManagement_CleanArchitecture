using HotelZZ.Api.DTOs;
using HotelZZ.Api.Models;
using HotelZZ.Application.Common.Files;
using HotelZZ.Application.Features.Rooms.Commands.CreateRoom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelZZ.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateRoomDto dto)
        {
            var command = new CreateRoomCommand(
                dto.RoomNumber,
                dto.Capacity,
                dto.Description,
                dto.PricePerNight,
                dto.HotelId,
                dto.RoomTypeId,
                dto.AmenityIds,
                dto.Images?.Select(f => (IImage)new FormFileImage(f)).ToList()
            );

            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok("Added successfully") : BadRequest(result.Errors);
        }
    }
}