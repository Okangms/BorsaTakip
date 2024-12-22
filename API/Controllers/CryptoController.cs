// API/Controllers/CryptoController.cs
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetCryptoByName(string symbol)
        {
            var result = await _cryptoService.GetCryptoByNameAsync(symbol);
            if (result == null)
                return NotFound($"{symbol} kripto parası bulunamadı.");

            return Ok(result);
        }

        [HttpGet("{indexId}/history")]
        public async Task<IActionResult> GetCryptoPriceHistory(string indexId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await _cryptoService.GetCryptoPriceHistoryAsync(indexId, startDate, endDate);
            if (result == null || result.Count == 0)
                return NotFound($"{indexId} için tarihsel veri bulunamadı.");

            return Ok(result);
        }
    }
}
