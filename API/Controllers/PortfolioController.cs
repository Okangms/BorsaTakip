using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        
        [AllowAnonymous]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserPortfolios(int userId)
        {
            // Kullanıcının id'sini doğrulamak için bir güvenlik katmanı ekleyin
            var portfolios = await _portfolioService.GetPortfoliosByUserIdAsync(userId);
            return Ok(portfolios);

        }

        [HttpGet("total-value/{userId}")]
        [AllowAnonymous] // İsterseniz kimlik doğrulama yapabilirsiniz
        public async Task<IActionResult> GetPortfolioTotalValue(int userId)
        {
            try
            {
                var totalValue = await _portfolioService.CalculatePortfolioTotalValueAsync(userId);
                return Ok(new { TotalValue = totalValue });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddCryptoToPortfolio([FromBody] PortfolioItem portfolioItem)
        {
            var userId = int.Parse(User.FindFirst("id")?.Value);

            // Kullanıcıya ait portföyü al veya oluştur
            var portfolio = await _portfolioService.GetOrCreateUserPortfolioAsync(userId);

            portfolioItem.PortfolioId = portfolio.Id;
            await _portfolioService.AddCryptoToPortfolioAsync(portfolioItem);

            return Ok("Crypto added to portfolio successfully.");
        }

        [HttpGet("total-value")]
        public async Task<IActionResult> GetPortfolioTotalValue()
        {
            var userId = int.Parse(User.FindFirst("id")?.Value);

            var totalValue = await _portfolioService.CalculatePortfolioTotalValueAsync(userId);
            return Ok(totalValue);
        }
    }
}
