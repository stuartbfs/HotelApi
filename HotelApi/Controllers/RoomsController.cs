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
            [FromQuery] DateTime checkInDate, 
            [FromQuery] DateTime checkOutDate, 
            [FromQuery] int partySize,
            CancellationToken token = default)
        {
            return await this.Handle(async () =>
            {
                var result = await _mediator.Send(new HotelRoomAvailabilityRequest(hotelId, checkInDate, checkOutDate, partySize), token);
                return Ok(result);
            });
        }

        [HttpGet("availability")]
        public async Task<IActionResult> Availability(
            [FromQuery] DateTime checkInDate, 
            [FromQuery] DateTime checkOutDate, 
            [FromQuery] int partySize, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10,
            CancellationToken token = default)
        {
            return await this.Handle(async () =>
            {
                var result = await _mediator.Send(new HotelsAvailabilityRequest(checkInDate, checkOutDate, partySize, page, pageSize), token);
                return Ok(result);
            });
        }
    }
}
