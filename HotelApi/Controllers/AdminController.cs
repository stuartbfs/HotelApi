using HotelDomain.Data;
using HotelDomain.Data.Seed;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly HotelsDbContext _context;

        public AdminController(HotelsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost(nameof(Reset))]
        public async Task<IActionResult> Reset()
        {
            await HotelsDbContextDataSeed.Initialize(_context);
            return Ok();
        }
    }
}
