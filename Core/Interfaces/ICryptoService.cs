using Core.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICryptoService
    {
        Task<List<Coin>> GetCryptoDataAsync();
        Task<Coin> GetCryptoByNameAsync(string symbol);
        Task<List<CryptoIndexWithComposition>> GetCryptoPriceHistoryAsync(string indexId, DateTime startDate, DateTime endDate);
    }
}
