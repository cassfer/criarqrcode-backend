using CriarQrCode_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriarQrCode_backend.Controllers
{
    [ApiController]
    [Route("createQrCode")]
    public class CreateQrCodeController : ControllerBase
    {

        private readonly CreateQrCodeService _createQrCodeService;

        private readonly ILogger<CreateQrCodeController> _logger;


        public CreateQrCodeController(ILogger<CreateQrCodeController> logger, CreateQrCodeService createQrCodeService)
        {
            _logger = logger;
            _createQrCodeService = createQrCodeService;
        }

        [HttpGet(Name = "home")]
        public string Get()
        {
            const string text = "Texto de teste!";
            return this._createQrCodeService.createQrCodeFromText(text);

        }
    }
}
