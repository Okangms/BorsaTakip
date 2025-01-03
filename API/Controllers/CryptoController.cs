﻿// API/Controllers/CryptoController.cs
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

        //[HttpGet]
        //public async Task<IActionResult> GetCryptos()
        //{
        //    var result = await _cryptoService.GetCryptoDataAsync();
        //    if (result == null)
        //        return NotFound("Kripto para verisi bulunamadı.");

        //    return Ok(result);
        //}

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetCryptoByName(string symbol)
        {
            var result = await _cryptoService.GetCryptoByNameAsync(symbol);
            if (result == null)
                return NotFound($"{symbol} kripto parası bulunamadı.");

            return Ok(result);
        }
    }
}
