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
    public class ManageController : ControllerBase
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IPhoneService _phoneService;
        private readonly Config _config;

        public ManageController(
            ILogger<ManageController> logger,
            IOptions<Config> config,
            IPhoneService phoneService)
        {
            _logger = logger;
            _phoneService = phoneService;
            _config = config.Value;
        }

        [HttpPost]
        public async Task<IActionResult> AddPhone()
        {
            return Ok(await _phoneService.AddAsync("Test"));
        }
    }
}