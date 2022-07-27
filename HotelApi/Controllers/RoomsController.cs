using HotelApi.Infrastructure;
using HotelDomain.Queries.HotelRoomAvailability;
using HotelDomain.Queries.HotelsAvailability;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{hotelId}/availability")]
        public async Task<IActionResult> Availability(
            [FromRoute] Guid hotelId, 
            [FromQuery] DateTime checkIn, 
            [FromQuery] DateTime checkOut, 
            [FromQuery] int partySize,
            CancellationToken token = default)
        {
            return await this.Handle(async () =>
            {
                var result = await _mediator.Send(new HotelRoomAvailabilityRequest(hotelId, checkIn, checkOut, partySize), token);
                return Ok(result);
            });
        }

        [HttpGet("availability")]
        public async Task<IActionResult> Availability(
            [FromQuery] DateTime checkIn, 
            [FromQuery] DateTime checkOut, 
            [FromQuery] int partySize, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10,
            CancellationToken token = default)
        {
            return await this.Handle(async () =>
            {
                var result = await _mediator.Send(new HotelsAvailabilityRequest(checkIn, checkOut, partySize, page, pageSize), token);
                return Ok(result);
            });
        }
    }
}
