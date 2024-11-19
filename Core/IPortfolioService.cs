using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Core
{
    public interface IPortfolioService
    {
        Task<IEnumerable<UserPortfolio>> GetAllPortfoliosAsync();
        Task<UserPortfolio> GetPortfolioByIdAsync(int portfolioId);
        Task<UserPortfolio> AddPortfolioAsync(UserPortfolio portfolio);
        Task<bool> UpdatePortfolioAsync(UserPortfolio portfolio);
        Task<bool> DeletePortfolioAsync(int portfolioId);
    }
}
