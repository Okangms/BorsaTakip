using Core;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

using Core.Entities;


namespace Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly CryptoTrackingContext _dbContext;

        public PortfolioService(CryptoTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Portfolio>> GetAllPortfoliosAsync(int UserId)
        {
            return await _dbContext.Portfolios
            .Where(p => p.UserId == UserId)
            .Include(p => p.UserPortfolios)
            .ThenInclude(up => up.Coin)
            .ToListAsync();
        }


        public async Task<Portfolio> GetPortfolioByIdAsync(int PortfolioId, int UserId)
        {
            var portfolio = await _dbContext.Portfolios
                .Where(p => p.PortfolioId == PortfolioId && p.UserId == UserId)
                .Include(p => p.UserPortfolios)
                .ThenInclude(up => up.Coin)
                .FirstOrDefaultAsync();

            if (portfolio == null) return null;

            foreach (var userPortfolio in portfolio.UserPortfolios)
            {
                var coin = userPortfolio.Coin;
                userPortfolio.Coin = new Coin
                {
                    Id = coin.Id,
                    Symbol = coin.Symbol,
                    CurrentPrice = coin.CurrentPrice,
                    Name = coin.Name,
                };
            }
            return portfolio;
        }


        public async Task<bool> CreatePortfolioByIdAsync(int userId, string portfolioName)
        {
            var newaportfolio = new Portfolio
            {
                UserId = userId,
                PortfolioName = portfolioName,
            };

            _dbContext.Portfolios.Add(newaportfolio);
            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task<bool> AddToPortfolioAsync(int portfolioId, int coinId, int amount)
        {
            var coinExist = await _dbContext.CryptoAssets.AnyAsync(c => c.Id == coinId);
            if (!coinExist) return false;

            var UserPortfolio = new UserPortfolio
            {
                PortfolioId = portfolioId,
                Id = coinId,
                Amount = amount
            };

            _dbContext.UserPortfolio.Add(UserPortfolio);
            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeleteFromPortfolioAsync(int portfolioId, int userId, int coinId)
        {
            var userPortfolio = await _dbContext.UserPortfolio
                .FirstOrDefaultAsync(up =>
                    up.PortfolioId == portfolioId &&
                    up.Portfolio.UserId == userId &&
                    up.Id == coinId);

            if (userPortfolio == null) return false;

            _dbContext.UserPortfolio.Remove(userPortfolio);
            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeletePortfolioAsync(int portfolipId, int userId)
        {
            var portfolio = await _dbContext.Portfolios
                .FirstOrDefaultAsync(p =>
                p.PortfolioId == portfolipId &&
                p.User.UserId == userId);

            if (portfolio == null) return false;

            _dbContext.Portfolios.Remove(portfolio);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }


}
