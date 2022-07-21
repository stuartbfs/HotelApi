using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet("{hotelId}")]
        public IActionResult Availablity([FromRoute]Guid hotelId, [FromQuery] DateTime checkInDate, [FromQuery] DateTime checkOutDate, [FromQuery] int numberOfPeople)
        {
            return Ok();
        }
    }
}
