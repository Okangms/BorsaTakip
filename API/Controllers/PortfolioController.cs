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

        [HttpGet("user/userId")]
        public async Task<IActionResult> GetAllPortfolios(int userId)
        {
            var portfolios = await _portfolioService.GetAllPortfoliosAsync(userId);
            if(portfolios==null || !portfolios.Any())
            {
                NotFound("portfolye bulunamadı");
            }
            return Ok(portfolios);
        }



        [HttpGet("user/{userId}/portfolio/{portfolioId}")]
        public async Task<IActionResult> GetPortfolioById(int portfolioId ,int userId)
        {
            var portfolio = await _portfolioService.GetPortfolioByIdAsync(portfolioId ,userId );
            if (portfolio == null)
            {
                return NotFound("bu portföy boş");
            }

            return Ok(portfolio);
        }


        [HttpPost("user/{userId}")]
        public async Task<IActionResult> CreatePortfolio(int userId, [FromBody] string portfolioName)
        {
            if (string.IsNullOrWhiteSpace(portfolioName))
            {
                return BadRequest("bir isim girmeniz gerekli");
            }

            var result = await _portfolioService.CreatePortfolioByIdAsync(userId,portfolioName);
            if (!result)
            {
                return StatusCode(500,"portfolye oluştururken bi sorun oluştu!");
            }

            return Ok("portfolye oluşturuldu");
        }


        [HttpPost("portfolio/{portfolioId}/coin/{coinId}")]
        public async Task<IActionResult> AddToPortfolio(int portfolioId,int coinId, [FromBody]int amount)
        {
            if (amount >=0)
            {
                BadRequest("miktar 0'dan büyük olmalı");
            }
            var result = await _portfolioService.AddToPortfolioAsync(portfolioId,coinId,amount);
            if (!result)
            {
                return BadRequest("ekleme işlemi yapılamadı");
            }

            return Ok("başarıyla coin eklendi");
        }


        [HttpDelete("portfolio/{portfolioId}/coin/{coinId}/user/{userId}")]
        public async Task<IActionResult> DeleteFromPortfolio(int portfolioId,int userId,int coinId)
        {
            var result = await _portfolioService.DeleteFromPortfolioAsync(portfolioId,userId,coinId);
            if (!result)
            {
                return NotFound("silinemedi");
            }
            return Ok("silindi");
        }


        [HttpDelete("user/{userId}/portfolio/{portfolioId}")]
        public async Task<IActionResult> DeletePortfolio(int portfolioId ,int userId)
        {
            var result = await _portfolioService.DeletePortfolioAsync(portfolioId ,userId );
            if (!result)
            {
                return NotFound("portföy silinemedi");
            }
            return Ok("başarıyla silindi");

        }
    }








}
