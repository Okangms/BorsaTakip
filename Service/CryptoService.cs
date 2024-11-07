using Core;
using Newtonsoft.Json;
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
        }

        public async Task<List<Coin>> GetCryptoDataAsync()
        {
            var url = "coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var coins = JsonConvert.DeserializeObject<List<Coin>>(responseString);
            return coins;
        }

    }
}
