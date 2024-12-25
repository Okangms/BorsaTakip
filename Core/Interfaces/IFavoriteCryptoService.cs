using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IFavoriteCryptoService
    {
     
        Task<IEnumerable<FavoriteCrypto>> GetFavoritesByUserIdAsync(int userId);

   
        Task AddFavoriteAsync(int userId, string cryptoSymbol);

      
        Task RemoveFavoriteAsync(int userId, string cryptoSymbol);
    }
}
