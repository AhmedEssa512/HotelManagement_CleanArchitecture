using HotelZZ.Application.Features.RoomTypes.Commands.CreateRoomType;
using HotelZZ.Application.Features.RoomTypes.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelZZ.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomTypeCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok("Added successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetRoomTypeByIdQuery(id));

            if (result.IsFailure)
                return NotFound(result.Errors);

            return Ok(result.Value);
        }
    }
}