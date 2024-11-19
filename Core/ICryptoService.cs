using Newtonsoft.Json;



namespace Core


{
    public interface ICryptoService
    {
        Task<List<Coin>> GetCryptoDataAsync();
    }

  
}
