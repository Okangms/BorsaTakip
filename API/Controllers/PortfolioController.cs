using Core;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPortfolio>>> GetAllPortfolios()
        {
            var portfolios = await _portfolioService.GetAllPortfoliosAsync();
            return Ok(portfolios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserPortfolio>> GetPortfolio(int id)
        {
            var portfolio = await _portfolioService.GetPortfolioByIdAsync(id);
            if (portfolio == null) return NotFound();

            return Ok(portfolio);
        }


        [HttpPost]
        public async Task<ActionResult<UserPortfolio>> AddPortfolio(UserPortfolio portfolio)
        {
            var newPortfolio = await _portfolioService.AddPortfolioAsync(portfolio);
            return CreatedAtAction(nameof(GetPortfolio),
                new { id = newPortfolio.PortfolioId }, newPortfolio);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortfolio(int id, UserPortfolio userPortfolio)
        {
            if (id != userPortfolio.PortfolioId) return BadRequest();

            var success = await _portfolioService.UpdatePortfolioAsync(userPortfolio);
            if(!success) return NotFound();

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var success = await _portfolioService.DeletePortfolioAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }


    }








}
