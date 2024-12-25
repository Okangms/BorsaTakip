using Core.Entities;
using Core.Services;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class FavoriteCryptoService : IFavoriteCryptoService
    {
        private readonly IFavoriteCryptoRepository _favoriteCryptoRepository;

        public FavoriteCryptoService(IFavoriteCryptoRepository favoriteCryptoRepository)
        {
            _favoriteCryptoRepository = favoriteCryptoRepository;
        }

        public async Task<IEnumerable<FavoriteCrypto>> GetFavoritesByUserIdAsync(int userId)
        {
            return await _favoriteCryptoRepository.GetFavoritesByUserIdAsync(userId);
        }

        public async Task AddFavoriteAsync(int userId, string cryptoSymbol)
        {
            var favoriteCrypto = new FavoriteCrypto
            {
                UserId = userId,
                CryptoSymbol = cryptoSymbol
            };

            await _favoriteCryptoRepository.AddFavoriteAsync(favoriteCrypto);
        }

        public async Task RemoveFavoriteAsync(int userId, string cryptoSymbol)
        {
            await _favoriteCryptoRepository.RemoveFavoriteAsync(userId, cryptoSymbol);
        }
    }
}
