using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class CoinPrice
    {
        public int Id { get; set; }
        public int CoinId { get; set; }
        public decimal AskPrice { get; set; }
        public Coin Coin { get; set; }
    }
}
