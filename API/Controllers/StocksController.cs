using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpGet("{symbols}")]
        public async Task<IActionResult> GetStockBySymbol(string symbols)
        {
            var result = await _stockService.GetStockBySymbolAsync(symbols);
            if (result == null)
                return NotFound("Hisse senedi bulunamadı.");

            return Ok(result);
        }
    }
}