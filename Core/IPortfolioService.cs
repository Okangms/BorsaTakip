using Core.Entities;
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
        Task<IEnumerable<Portfolio>> GetAllPortfoliosAsync(int UserId);
        Task<Portfolio> GetPortfolioByIdAsync(int portfolioId,int UserId);
        Task<bool> CreatePortfolioByIdAsync(int UserId, string PortfolioName);
        Task<bool> AddToPortfolioAsync(int portfolioId,int coinId,int amount);
        Task<bool> DeleteFromPortfolioAsync(int portfolioId,int UserId, int coinId);
        Task<bool> DeletePortfolioAsync(int portfolioId,int UserId);  
    }
}
