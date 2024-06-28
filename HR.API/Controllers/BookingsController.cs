using HR.API.Models;
using HR.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly IMessageProducer _messageProducer;

        //In-Memory Data Storage
        public static readonly List<Booking> _bookings = new();

        public BookingsController(ILogger<BookingsController> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking newBooking)
        {
            if (!ModelState.IsValid) return BadRequest();

            _bookings.Add(newBooking);
            _messageProducer.SendingMessage<Booking>(newBooking);

            return Ok();
        }
    }
}
