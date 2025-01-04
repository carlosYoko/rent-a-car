using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Vehicles.SearchVehicles;

namespace RentACar.Api.Controllers.Vehicles
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly ISender _sender;

        public VehiclesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchVehicles(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            var query = new SearchVehiclesQuery(startDate, endDate);
            var result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
