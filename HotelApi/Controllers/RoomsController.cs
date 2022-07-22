using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet("{hotelId}/availability")]
        public IActionResult Availability(
            [FromRoute] Guid hotelId, 
            [FromQuery] DateTime checkInDate, 
            [FromQuery] DateTime checkOutDate, 
            [FromQuery] int partySize)
        {
            return Ok();
        }

        [HttpGet("availability")]
        public IActionResult Availability(
            [FromQuery] DateTime checkInDate, 
            [FromQuery] DateTime checkOutDate, 
            [FromQuery] int partySize, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10)
        {
            return Ok();
        }
    }
}
