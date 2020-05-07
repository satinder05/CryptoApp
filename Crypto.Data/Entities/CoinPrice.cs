namespace Crypto.Data.Entities
{
    public class CoinPrice
    {
        public int Id { get; set; }
        public int CoinId { get; set; }
        public decimal AskPrice { get; set; }
        public Coin Coin { get; set; }
    }
}
