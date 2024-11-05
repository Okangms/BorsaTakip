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
        private const string ApiKey = "9fbfcde5af083b237eda25ea30a25d81"; // Your API key

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetStockBySymbolAsync(string symbols)
        {
            // Construct the URL with the API key and symbols
            var url = $"/v1/intraday?access_key={ApiKey}&symbols={symbols}";//ekleme yapacaksan api uzantısındaki intradayi istediğin uzantıuyla değiştir

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
