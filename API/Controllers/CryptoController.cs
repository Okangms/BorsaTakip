using Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCryptos()
        {
            var result = await _cryptoService.GetCryptoDataAsync();
            if (result == null)
                return NotFound("Kripto para verisi bulunamadı.");

            return Ok(result);
        }
    }
}
