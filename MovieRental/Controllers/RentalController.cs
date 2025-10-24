using Microsoft.AspNetCore.Mvc;
using MovieRental.Rental;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Rental.Rental rental)
        {
            return Ok(_features.SaveAsync(rental));
        }

        [HttpGet("Customer/{name}")]
        public async Task<ActionResult<IEnumerable<Rental.Rental>>> GetRentalsByCustomerName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("The name is mandatory.");

            var rentals = await _features.GetRentalsByCustomerNameAsync(name);

            if (!rentals.Any())
                return NotFound("No rentals found for this customer.");

            return Ok(rentals);
        }
    }
}
