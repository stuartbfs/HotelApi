using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost(nameof(Seed))]
        public IActionResult Seed()
        {
            return Ok();
        }

        [HttpPost(nameof(Reset))]
        public IActionResult Reset()
        {
            return Ok();
        }
    }
}
