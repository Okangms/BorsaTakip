using Core.Entities;
using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FavoriteCryptoRepository : IFavoriteCryptoRepository
    {
        private readonly CryptoDbContext _context;

        public FavoriteCryptoRepository(CryptoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FavoriteCrypto>> GetFavoritesByUserIdAsync(int userId)
        {
            return await _context.FavoriteCryptos
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task AddFavoriteAsync(FavoriteCrypto favoriteCrypto)
        {
            _context.FavoriteCryptos.Add(favoriteCrypto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteAsync(int userId, string cryptoSymbol)
        {
            var favorite = await _context.FavoriteCryptos
                .FirstOrDefaultAsync(f => f.UserId == userId && f.CryptoSymbol == cryptoSymbol);

            if (favorite != null)
            {
                _context.FavoriteCryptos.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }
    }
}
