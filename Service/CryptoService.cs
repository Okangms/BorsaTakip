// Service/CryptoService.cs
using Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;

        public CryptoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("X-CoinAPI-Key", "5D872D11-1630-466A-B664-02CFC948F8F4"); // API anahtarı ekleniyor
        }

        public async Task<List<Coin>> GetCryptoDataAsync()
        {
            var url = "v1/assets"; // CoinAPI'nin varlık bilgilerini almak için uç noktası
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var coins = JsonConvert.DeserializeObject<List<Coin>>(responseString);
            return coins;
        }

        public async Task<Coin> GetCryptoByNameAsync(string symbol)
        {
            var url = $"v1/assets/{symbol}"; // Belirli bir coin sembolü için uç nokta
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var coin = JsonConvert.DeserializeObject<List<Coin>>(responseString)?.FirstOrDefault();
            return coin;
        }
    }
}
