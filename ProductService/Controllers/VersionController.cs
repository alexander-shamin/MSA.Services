using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        private static readonly string _version = GetEnvVar("SERVICE_VERSION", "UNKNOWN");
        private static readonly string _buildNumber = GetEnvVar("SERVICE_BUILD_NUMBER", "UNKNOWN");
        private static readonly string _gitCommit = GetEnvVar("SERVICE_GIT_COMMIT", "UNKNOWN");

        private static string GetEnvVar(string key, string defaultValue = null!)
            => Environment.GetEnvironmentVariable(key) ?? defaultValue;

        private readonly ILogger<VersionController> _logger;

        public VersionController(ILogger<VersionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            return new
            {
                Version = _version,
                BuildNumber = _buildNumber,
                GitCommit = _gitCommit
            };
        }
    }
}