using Microsoft.AspNetCore.Mvc;
using CriarQrCode_backend.Model;

namespace CriarQrCode_backend.Controllers
{
    [ApiController]
    [Route("createQrCode")]
    public class CreateQrCodeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CreateQrCodeController> _logger;


        public CreateQrCodeController(ILogger<CreateQrCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "home")]
        public string Get()
        {
            return ("Retorno positivo!");
        }
    }
}
