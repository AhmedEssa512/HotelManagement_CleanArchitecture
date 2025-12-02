using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelZZ.Application.Features.Amenities.Commands.CreateAmenity;
using HotelZZ.Application.Features.Amenities.Queries.GetById;

namespace HotelZZ.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AmenitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateAmenityCommand command)
        {
            var result = await _mediator.Send(command);

            if(result.IsFailure)
             return BadRequest(result.Errors);

            return Ok("Added Successfully");
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAmenityByIdQuery(id));

            if(result.IsFailure)
             return NotFound(result.Errors);

            return Ok(result.Value);
        }
    }
}