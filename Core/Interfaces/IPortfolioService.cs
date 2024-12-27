// Core/Services/IPortfolioService.cs
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPortfolioService
    {
        Task<IEnumerable<Portfolio>> GetPortfoliosByUserIdAsync(int userId);
        Task AddCryptoToPortfolioAsync(PortfolioItem portfolioItem);
        Task<decimal> CalculatePortfolioTotalValueAsync(int userId);
        Task<Portfolio> GetOrCreateUserPortfolioAsync(int userId);
    }

}
