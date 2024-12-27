using Core.Entities;
using Core.Interfaces;
using Core.Services;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly ICryptoService _cryptoService;

        public PortfolioService(IPortfolioRepository portfolioRepository, ICryptoService cryptoService)
        {
            _portfolioRepository = portfolioRepository;
            _cryptoService = cryptoService;
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(int portfolioId)
        {
            return await _portfolioRepository.GetPortfolioByIdAsync(portfolioId);
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosByUserIdAsync(int userId)
        {
            return await _portfolioRepository.GetPortfoliosByUserIdAsync(userId);
        }

        public async Task AddPortfolioAsync(Portfolio portfolio)
        {
            await _portfolioRepository.AddPortfolioAsync(portfolio);
        }

        public async Task UpdatePortfolioAsync(Portfolio portfolio)
        {
            await _portfolioRepository.UpdatePortfolioAsync(portfolio);
        }

        public async Task DeletePortfolioAsync(int portfolioId)
        {
            await _portfolioRepository.DeletePortfolioAsync(portfolioId);
        }

        public async Task<Portfolio> GetOrCreateUserPortfolioAsync(int userId)
        {
            var portfolios = await _portfolioRepository.GetPortfoliosByUserIdAsync(userId);
            var portfolio = portfolios.FirstOrDefault();

            if (portfolio == null)
            {
                portfolio = new Portfolio
                {
                    UserId = userId,
                    Name = "Default Portfolio",
                    Items = new List<PortfolioItem>()
                };

                await _portfolioRepository.AddPortfolioAsync(portfolio);
            }

            return portfolio;
        }

        public async Task AddCryptoToPortfolioAsync(PortfolioItem portfolioItem)
        {
            var portfolio = await _portfolioRepository.GetPortfolioByIdAsync(portfolioItem.PortfolioId);

            if (portfolio == null)
                throw new KeyNotFoundException("Portfolio not found");

            if (portfolio.Items.Any(i => i.CryptoSymbol == portfolioItem.CryptoSymbol))
            {
                var existingItem = portfolio.Items.First(i => i.CryptoSymbol == portfolioItem.CryptoSymbol);
                existingItem.Quantity += portfolioItem.Quantity;
            }
            else
            {
                portfolio.Items.Add(portfolioItem);
            }

            await _portfolioRepository.UpdatePortfolioAsync(portfolio);
        }

        public async Task<decimal> CalculatePortfolioTotalValueAsync(int userId)
        {
            var portfolios = await _portfolioRepository.GetPortfoliosByUserIdAsync(userId);
            var portfolio = portfolios.FirstOrDefault();

            if (portfolio == null || portfolio.Items.Count == 0)
            {
                return 0;
            }

            decimal totalValue = 0;

            foreach (var item in portfolio.Items)
            {
                var crypto = await _cryptoService.GetCryptoByNameAsync(item.CryptoSymbol);

                if (crypto != null && crypto.CurrentPrice.HasValue)
                {
                    totalValue += item.Quantity * crypto.CurrentPrice.Value;
                }
            }

            return totalValue;
        }
    }
}
