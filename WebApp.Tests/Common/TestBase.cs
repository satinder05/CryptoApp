using Crypto.Data.Persistence;
using System;

namespace WebApp.Tests.Common
{
    public class TestBase : IDisposable
    {
        protected readonly CryptoDbContext _context;

        public TestBase()
        {
            _context = CryptoDbContextFactory.Create();
        }

        public void Dispose()
        {
            CryptoDbContextFactory.Destroy(_context);
        }
    }
}
