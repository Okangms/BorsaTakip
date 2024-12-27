using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IFavoriteCryptoRepository
    {
        Task<IEnumerable<FavoriteCrypto>> GetFavoritesByUserIdAsync(int userId);
        Task AddFavoriteAsync(FavoriteCrypto favoriteCrypto);
        Task RemoveFavoriteAsync(int userId, string cryptoSymbol);
    }
}
