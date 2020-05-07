using Crypto.Data.Entities;
using Crypto.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Service
{
    public class CoinService
    {
        private readonly CryptoDbContext _context;
        private readonly ILogger _logger;

        public CoinService(CryptoDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<List<Coin>> GetAllCoins()
        {
            try
            {
                var coins = _context.Coins.ToListAsync();
                return coins;
            }
            catch(Exception exception)
            {
                _logger.LogWarning(exception, "Error fetching coin list at {RequestTime}", DateTime.Now);
                throw exception;
            }
        }
    }
}
