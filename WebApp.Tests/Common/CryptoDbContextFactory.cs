using Crypto.Data.Entities;
using Crypto.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Tests.Common
{
    public class CryptoDbContextFactory
    {
        public static CryptoDbContext Create()
        {
            var options = new DbContextOptionsBuilder<CryptoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new CryptoDbContext(options);
            context.Database.EnsureCreated();

            //Add Test data
            context.Coins.AddRange(new[] {
                new Coin { Symbol = "BTC"},
                new Coin { Symbol = "ETH"},
                new Coin { Symbol = "XRP"}
            });

            return context;
        }

        public static void Destroy(CryptoDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
