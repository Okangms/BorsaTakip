using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCryptoController : ControllerBase
    {
        private readonly IFavoriteCryptoService _favoriteCryptoService;

        public FavoriteCryptoController(IFavoriteCryptoService favoriteCryptoService)
        {
            _favoriteCryptoService = favoriteCryptoService;
        }

        [HttpGet("{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFavorites(int userId)
        {
            var favorites = await _favoriteCryptoService.GetFavoritesByUserIdAsync(userId);
            return Ok(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] FavoriteCrypto favoriteCrypto)
        {
            await _favoriteCryptoService.AddFavoriteAsync(favoriteCrypto.UserId, favoriteCrypto.CryptoSymbol);
            return Ok("Crypto added to favorites.");
        }

        [HttpDelete("{userId}/{cryptoSymbol}")]
        public async Task<IActionResult> RemoveFavorite(int userId, string cryptoSymbol)
        {
            await _favoriteCryptoService.RemoveFavoriteAsync(userId, cryptoSymbol);
            return Ok("Crypto removed from favorites.");
        }
    }
}
