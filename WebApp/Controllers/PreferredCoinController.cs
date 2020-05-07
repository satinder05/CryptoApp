using System.Threading.Tasks;
using Crypto.Data.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Model;
using WebApp.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PreferredCoinController : Controller
    {
        private readonly CryptoDbContext _context;
        private readonly ILogger<PreferredCoinController> _logger;

        public PreferredCoinController(CryptoDbContext context, ILogger<PreferredCoinController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpPost]
        public async Task<int> SavePreferredCoin([FromBody] int id)
        {
            var service = new UserPreferenceService(_context, _logger);
            return await service.SavePreferredCoin(id);
        }

        [HttpGet]
        public async Task<int> GetPreferredCoin()
        {
            var service = new UserPreferenceService(_context, _logger);
            return await service.GetPreferredCoinId();
        }

        [HttpGet("TradeData")]
        public async Task<TradeData> GetTradeData()
        {
            int preferredCoinId = await new UserPreferenceService(_context, _logger).GetPreferredCoinId();
            var tradeDataService = new TradeDataService(_context, _logger);
            return await tradeDataService.GetTradeData(preferredCoinId);
        }
    }
}