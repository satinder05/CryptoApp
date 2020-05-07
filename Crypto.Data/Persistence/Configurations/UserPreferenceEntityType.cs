using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Crypto.Data.Entities;

namespace Crypto.Data.Persistence.Configurations
{
    public class UserPreferenceEntityType : IEntityTypeConfiguration<UserPreference>
    {
        public void Configure(EntityTypeBuilder<UserPreference> builder)
        {
            builder.ToTable("UserPreferences");

            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.CoinId)
                    .HasColumnName("CoinId")
                    .IsRequired();
        }
    }
}
