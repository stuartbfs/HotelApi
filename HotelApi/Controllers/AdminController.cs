using HotelApi.Infrastructure;
using HotelDomain.Data;
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

        [HttpPost]
        public async Task<IActionResult> Seed()
        {
            await HotelsDbContextDataSeed.SeedBookings(_context);
            return Ok();
        }
    }
}
