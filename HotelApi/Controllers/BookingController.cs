﻿using HotelApi.Infrastructure;
using HotelDomain.Commands.BookRoom;
using HotelDomain.Queries.FindBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string bookingRef,
            CancellationToken token = default)
        {
            return await this.Handle(async () =>
            {
                var result = await _mediator.Send(new FindBookingRequest(bookingRef), token);
                return Ok(result);
            });
        }

        [HttpPost("{hotelId}")]
        public async Task<IActionResult> Create(
            [FromRoute] Guid hotelId, 
            [FromBody] BookRoomRequestBody request,
            CancellationToken token = default)
        {
            return await this.Handle(async () =>
            {
                var result = await _mediator.Send(new BookRoomRequest(hotelId, request), token);
                return Ok(result);
            });
        }
    }
}
