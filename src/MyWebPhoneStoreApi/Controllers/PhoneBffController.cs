using System.Threading.Tasks;
using MyWebPhoneStoreApi.Configuration;
using MyWebPhoneStoreApi.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MyWebPhoneStoreApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class PhoneBffController : ControllerBase
    {
        private readonly ILogger<PhoneBffController> _logger;
        private readonly IPhoneService _phoneService;
        private readonly Config _config;

        public PhoneBffController(
            ILogger<PhoneBffController> logger,
            IOptions<Config> config,
            IPhoneService phoneService)
        {
            _logger = logger;
            _phoneService = phoneService;
            _config = config.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhone(int id)
        {
            return Ok(await _phoneService.GetAsync(id));
        }
    }
}