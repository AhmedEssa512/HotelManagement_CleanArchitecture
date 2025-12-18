using HotelZZ.Api.DTOs;
using HotelZZ.Api.Models;
using HotelZZ.Application.Common.Files;
using HotelZZ.Application.Features.Hotels.Commands.CreateHotel;
using HotelZZ.Application.Features.rooms.Queries.GetRooms;
using HotelZZ.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelZZ.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateHotelDto dto)
        {
            IImage? image = dto.Image is null ? null : new FormFileImage(dto.Image);

            var command = new CreateHotelCommand(
                dto.Name,
                dto.Description,
                image,
                dto.Address,
                dto.City,
                dto.Country
            );

            var result = await _mediator.Send(command);

            if(result.IsFailure)
              return BadRequest(result.Errors);
            
            return Ok("Added Successfully");
        }


        [HttpGet("{hotelId}/rooms")]
        public async Task<IActionResult> GetRooms(
            int hotelId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] RoomStatus? status = null)
        {
            var result = await _mediator.Send(
                new GetRoomsQuery(hotelId, pageNumber, pageSize, status));
            return Ok(result);
        }


        
    }
}