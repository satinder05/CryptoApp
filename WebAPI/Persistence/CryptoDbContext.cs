using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Model;
using WebAPI.Persistence.Configurations;

namespace WebAPI.Persistence
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
