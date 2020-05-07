using Crypto.Data.Entities;
using Crypto.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebAPI.Service
{
    public class UserPreferenceService
    {
        private readonly CryptoDbContext _context;
        private readonly ILogger _logger;
        private const int _defaultCoinId = 1;

        public UserPreferenceService(CryptoDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> GetPreferredCoinId()
        {
            int preferredCoinId = _defaultCoinId;
            try
            {
                var userPreference = await GetUserPreference();
                if(userPreference != null)
                    preferredCoinId = userPreference.CoinId;
            }
            catch(Exception exception)
            {
                _logger.LogWarning(exception, "Error fetching user preferred coin at {RequestTime}", DateTime.Now);
            }
            return preferredCoinId;
        }

        public async Task<int> SavePreferredCoin(int coinId)
        {
            var coin = await _context.Coins.FindAsync(coinId);
            if (coin == null)
            {
                _logger.LogWarning("Failed to save user preferred coin due to invalid coinId# {CoinId}", coinId);
                return 0;
            }
            var userPreference = await GetUserPreference();
            if (userPreference == null)
            {
                userPreference = new UserPreference { CoinId = coin.Id };
                _context.UserPreferences.Add(userPreference);
            }
            else
            {
                userPreference.CoinId = coin.Id;
            }
            await _context.SaveChangesAsync();
            return userPreference.Id;

        }

        private async Task<UserPreference> GetUserPreference()
        {
            var userPreference = await _context.UserPreferences.Include(c => c.Coin).FirstOrDefaultAsync();
            return userPreference;
        }
    }
}
