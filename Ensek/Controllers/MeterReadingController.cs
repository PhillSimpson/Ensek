using Ensek.Domain.Model;
using Ensek.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        public readonly IMeterReadingService _meterReadingService;
        public MeterReadingController(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }

        [HttpPost]
        [Route("/meter-reading-uploads")]
        public async Task<ActionResult<UpdateMeterReadingResponse>> Post(IFormFile file, CancellationToken cancellationToken)
        {
            var response = await _meterReadingService.UpdateMeterReadings(file, cancellationToken);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
