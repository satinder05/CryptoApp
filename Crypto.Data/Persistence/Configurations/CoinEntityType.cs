using Crypto.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crypto.Data.Persistence.Configurations
{
    public class CoinEntityType : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.ToTable("Coins");

            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.Symbol)
                    .HasColumnName("Symbol")
                    .IsRequired()
                    .IsUnicode(false);
        }
    }
}
