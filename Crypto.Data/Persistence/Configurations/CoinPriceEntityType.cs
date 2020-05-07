using Crypto.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crypto.Data.Persistence.Configurations
{
    public class CoinPriceEntityType : IEntityTypeConfiguration<CoinPrice>
    {
        public void Configure(EntityTypeBuilder<CoinPrice> builder)
        {
            builder.ToTable("CoinPrices");

            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.CoinId)
                    .HasColumnName("CoinId")
                    .IsRequired();

            builder.Property(e => e.AskPrice)
                    .HasColumnName("AskPrice");
        }
    }
}
