using Crypto.Data.Entities;
using Crypto.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Common.Helper;
using WebApp.Model;

namespace WebApp.Service
{
    public class TradeDataService
    {
        private readonly ILogger _logger;
        private readonly CryptoDbContext _context;

        public TradeDataService(CryptoDbContext context, ILogger logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<TradeData> GetTradeData(int coinId)
        {
            try
            {
                var coin = await _context.Coins.FindAsync(coinId);
                JObject jsonResponse = await HttpClientHelper.GetJsonResponse("https://trade.cointree.com/api/prices/aud/" + coin.Symbol);

                var newAskPrice = Convert.ToDecimal(jsonResponse["ask"]);
                var oldPrice = await SaveAskPrice(coinId, newAskPrice);
                decimal askPricePercetageChange = GetAskPricePercetageChange(newAskPrice, oldPrice);

                return new TradeData
                {
                    Bid = Convert.ToDecimal(jsonResponse["bid"]),
                    Ask = newAskPrice,
                    Rate = Convert.ToDecimal(jsonResponse["rate"]),
                    AskPriceChangePercent = askPricePercetageChange
                };
            }
            catch(Exception exception)
            {
                _logger.LogWarning(exception, "Error fetching trade data at {RequestTime}", DateTime.Now);
                throw exception;
            }

        }

        private decimal GetAskPricePercetageChange(decimal newAskPrice, decimal oldPrice)
        {
            decimal percentageChange = 0.00M;
            if (oldPrice == 0 || newAskPrice == 0)
                return percentageChange;
            percentageChange = ((newAskPrice - oldPrice) / oldPrice) * 100;
            return Math.Round(percentageChange, 2);
        }

        private async Task<decimal> SaveAskPrice(int coinId, decimal askPrice)
        {
            decimal oldAskPrice = 0.00m;
            var coinPrice = await _context.CoinPrices.Where(c => c.CoinId == coinId).SingleOrDefaultAsync();
            if(coinPrice != null)
            {
                oldAskPrice = coinPrice.AskPrice;
                coinPrice.AskPrice = askPrice;
            }
            else
            {
                coinPrice = new CoinPrice { CoinId = coinId, AskPrice = askPrice };
                _context.CoinPrices.Add(coinPrice);
            }
            await _context.SaveChangesAsync();
            return oldAskPrice;
        }
        
    }
}
