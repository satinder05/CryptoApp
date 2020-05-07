namespace WebAPI.Model
{
    public class UserPreference
    {
        public int Id { get; set; }
        public int CoinId { get; set; }
        public Coin Coin { get; set; }
    }
}
