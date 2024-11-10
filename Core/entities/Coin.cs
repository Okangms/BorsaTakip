// Core/Coin.cs
using Newtonsoft.Json;

namespace Core
{
    public class Coin
    {
        [JsonProperty("asset_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price_usd")]
        public decimal? CurrentPrice { get; set; }

        [JsonProperty("market_cap_usd")]
        public decimal? MarketCap { get; set; }

        [JsonProperty("volume_1day_usd")]
        public decimal? TotalVolume { get; set; }
    }
}
