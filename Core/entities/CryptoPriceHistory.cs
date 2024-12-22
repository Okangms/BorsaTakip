using Newtonsoft.Json;

public class CryptoIndexWithComposition
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonProperty("value")]
    public decimal Value { get; set; }

    [JsonProperty("composition")]
    public List<IndexComponent> Composition { get; set; }
}

public class IndexComponent
{
    [JsonProperty("asset_id")]
    public string AssetId { get; set; }

    [JsonProperty("weight")]
    public decimal Weight { get; set; }
}
