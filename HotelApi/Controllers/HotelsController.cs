using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string name = null, [FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            return Ok();
        }
    }
}
