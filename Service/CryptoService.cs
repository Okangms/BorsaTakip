using Core;
using Core.entities;
using Core.Interfaces;
using Newtonsoft.Json;
using System;
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
            _httpClient.DefaultRequestHeaders.Add("X-CoinAPI-Key", "5D872D11-1630-466A-B664-02CFC948F8F4");
        }

        // Tüm kripto varlıkları almak için kullanılır
        public async Task<List<Coin>> GetCryptoDataAsync()
        {
            var url = "v1/assets";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var coins = JsonConvert.DeserializeObject<List<Coin>>(responseString);
            return coins;
        }

        // Belirli bir kripto para birimini (symbol) almak için kullanılır
        public async Task<Coin> GetCryptoByNameAsync(string symbol)
        {
            var url = $"v1/assets/{symbol}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var coin = JsonConvert.DeserializeObject<List<Coin>>(responseString)?.FirstOrDefault();
            return coin;
        }

        // Belirli bir endeksin tarihsel verilerini almak için kullanılır
        public async Task<List<CryptoIndexWithComposition>> GetCryptoPriceHistoryAsync(string indexId, DateTime startDate, DateTime endDate)
        {
            // API uç noktasını ayarla
            var url = $"https://rest.coinapi.io/v1/indexes/{indexId}/history";
            var formattedStartDate = startDate.ToString("yyyy-MM-ddTHH:mm:ss");
            var formattedEndDate = endDate.ToString("yyyy-MM-ddTHH:mm:ss");

            // Tam URL'yi oluştur
            var requestUri = $"{url}?time_start={formattedStartDate}&time_end={formattedEndDate}&limit=100";

            // HTTP GET isteği oluştur
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-CoinAPI-Key", "5D872D11-1630-466A-B664-02CFC948F8F4");

            // İstek gönder ve yanıtı al
            var response = await _httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}, Details: {responseString}");
                return null;
            }

            // Yanıtı nesneye dönüştür
            var historyData = JsonConvert.DeserializeObject<List<CryptoIndexWithComposition>>(responseString);
            return historyData;
        }

        // Endeksin bileşim verilerini almak için kullanılır
        public async Task<CryptoIndexWithComposition> GetCryptoIndexWithCompositionAsync(string indexId)
        {
            var url = $"https://rest.coinapi.io/v1/indexes/{indexId}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-CoinAPI-Key", "5D872D11-1630-466A-B664-02CFC948F8F4");

            var response = await _httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}, Details: {responseString}");
                return null;
            }

            var indexData = JsonConvert.DeserializeObject<CryptoIndexWithComposition>(responseString);
            return indexData;
        }
    }
}
