namespace Core.Entities
{
    public class PortfolioItem
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public string CryptoSymbol { get; set; }
        public decimal Quantity { get; set; }
    }
}