using Core;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly CryptoTrackingContext _cryptoTrackingContext;

        public PortfolioService(CryptoTrackingContext context)
        {
            _cryptoTrackingContext = context;
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
