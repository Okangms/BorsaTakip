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

namespace Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly CryptoTrackingContext _cryptoTrackingContext;

        public PortfolioService(CryptoTrackingContext context)
        {
            _cryptoTrackingContext = context;
        }

        public async Task<IEnumerable<UserPortfolio>> GetAllPortfoliosAsync()
        {
            return await _cryptoTrackingContext.UserPortfolio.ToListAsync();
        }


        public async Task<UserPortfolio> GetPortfolioByIdAsync(int portfolioId)
        {
            return await _cryptoTrackingContext.UserPortfolio.FindAsync(portfolioId);
        }


        public async Task<UserPortfolio> AddPortfolioAsync(UserPortfolio userPortfolio)
        {
            _cryptoTrackingContext.UserPortfolio.Add(userPortfolio);
            await _cryptoTrackingContext.SaveChangesAsync();
            return userPortfolio;
        }


        public async Task<bool> UpdatePortfolioAsync(UserPortfolio userPortfolio)
        {
            var existingPortfolio = _cryptoTrackingContext.UserPortfolio.FindAsync(userPortfolio.Id);
            if (existingPortfolio == null) return false;

            _cryptoTrackingContext.Entry(existingPortfolio).CurrentValues.SetValues(userPortfolio);
            return true;
        }



        public async Task<bool> DeletePortfolioAsync(int portfolioId)
        {
            var portfolio = await _cryptoTrackingContext.UserPortfolio.FindAsync(portfolioId);
            if (portfolio == null) return false;

            _cryptoTrackingContext.UserPortfolio.Remove(portfolio);
            await _cryptoTrackingContext.SaveChangesAsync();
            return true;
        }


    }
}
