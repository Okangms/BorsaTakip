using Newtonsoft.Json;



namespace Core


{
    public interface ICryptoService
    {
        Task<List<Coin>> GetCryptoDataAsync();
    }

    public class Coin
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonProperty("total_volume")]
        public decimal TotalVolume { get; set; }
    }
}
