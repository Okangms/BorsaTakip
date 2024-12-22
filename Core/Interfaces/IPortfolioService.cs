// Core/Services/IPortfolioService.cs
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPortfolioService
    {
        Task<Portfolio> GetPortfolioByIdAsync(int portfolioId);
        Task<IEnumerable<Portfolio>> GetPortfoliosByUserIdAsync(int userId);
        Task AddPortfolioAsync(Portfolio portfolio);
        Task UpdatePortfolioAsync(Portfolio portfolio);
        Task DeletePortfolioAsync(int portfolioId);
    }
}
