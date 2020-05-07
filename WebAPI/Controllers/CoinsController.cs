using System.Collections.Generic;
using System.Threading.Tasks;
using Crypto.Data.Entities;
using Crypto.Data.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CoinsController : Controller
    {
        private readonly CryptoDbContext _context;
        private readonly ILogger<CoinsController> _logger;

        public CoinsController(CryptoDbContext context, ILogger<CoinsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<List<Coin>> GetAll()
        {
            var service = new CoinService(_context, _logger);
            return await service.GetAllCoins();
        }

    }
}
