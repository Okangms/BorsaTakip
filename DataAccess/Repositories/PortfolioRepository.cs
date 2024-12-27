// DataAccess/Repositories/PortfolioRepository.cs
using Core.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly CryptoDbContext _context;

        public PortfolioRepository(CryptoDbContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(int portfolioId)
        {
            return await _context.Portfolios
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == portfolioId);
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosByUserIdAsync(int userId)
        {
            return await _context.Portfolios
                .Where(p => p.UserId == userId)
                .Include(p => p.Items)
                .ToListAsync();
        }

        public async Task AddPortfolioAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePortfolioAsync(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePortfolioAsync(int portfolioId)
        {
            var portfolio = await GetPortfolioByIdAsync(portfolioId);
            if (portfolio != null)
            {
                _context.Portfolios.Remove(portfolio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
