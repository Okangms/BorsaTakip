// DataAccess/Repositories/Interfaces/IPortfolioRepository.cs
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> GetPortfolioByIdAsync(int portfolioId);
        Task<IEnumerable<Portfolio>> GetPortfoliosByUserIdAsync(int userId);
        Task AddPortfolioAsync(Portfolio portfolio);
        Task UpdatePortfolioAsync(Portfolio portfolio);
        Task DeletePortfolioAsync(int portfolioId);
    }
}
