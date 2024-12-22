// Service/PortfolioService.cs
using Core.Entities;
using Core.Services;
using DAL.Repositories.Interfaces; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
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
    }
}
