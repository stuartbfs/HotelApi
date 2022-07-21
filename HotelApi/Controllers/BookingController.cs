using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpPost("{hotelId}")]
        public IActionResult Create([FromRoute] Guid hotelId, [FromBody] CreateBody request)
        {
            return Ok();
        }

        public class CreateBody
        {
            public DateTime CheckInDate { get; set; }

            public DateTime CheckOutDate { get; set; }

            public int NumberOfPeople { get; set; }
        }
    }
}
