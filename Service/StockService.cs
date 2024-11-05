using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;
        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetStockBySymbolAsync(string symbols)
        {
            var response = await _httpClient.GetAsync($"/tickers/{symbols}?access_key=7456bb95297ecd0d7db61216f0471dae");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

       
    }
}
