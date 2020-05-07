using Crypto.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Crypto.Data.Persistence.Configurations;

namespace Crypto.Data.Persistence
{
    public class CryptoDbContext : DbContext
    {
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options)
        {
        }

        public virtual DbSet<UserPreference> UserPreferences { get; set; }
        public virtual DbSet<Coin> Coins { get; set; }

        public virtual DbSet<CoinPrice> CoinPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserPreferenceEntityType());
            builder.ApplyConfiguration(new CoinEntityType());
            builder.ApplyConfiguration(new CoinPriceEntityType());
        }
    }
}
