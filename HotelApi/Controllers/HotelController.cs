using HotelApi.Infrastructure;
using HotelDomain.Queries.FindHotel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken token = default)
        {
            return await this.Handle(async () =>
            {
                var result = await _mediator.Send(new FindHotelRequest(name, page, pageSize), token);
                return Ok(result.Hotels);
            });
        }
    }
}
