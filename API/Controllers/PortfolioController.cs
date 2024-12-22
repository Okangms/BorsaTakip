// API/Controllers/PortfolioController.cs
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;

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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPortfoliosByUser(int userId)
        {
            var portfolios = await _portfolioService.GetPortfoliosByUserIdAsync(userId);
            return Ok(portfolios);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolio([FromBody] Portfolio portfolio)
        {
            await _portfolioService.AddPortfolioAsync(portfolio);
            return CreatedAtAction(nameof(GetPortfoliosByUser), new { userId = portfolio.UserId }, portfolio);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortfolio([FromBody] Portfolio portfolio)
        {
            await _portfolioService.UpdatePortfolioAsync(portfolio);
            return NoContent();
        }

        [HttpDelete("{portfolioId}")]
        public async Task<IActionResult> DeletePortfolio(int portfolioId)
        {
            await _portfolioService.DeletePortfolioAsync(portfolioId);
            return NoContent();
        }
    }
}
