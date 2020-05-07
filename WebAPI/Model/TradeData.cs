using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class TradeData
    {
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
        public decimal Rate { get; set; }
        public decimal AskPriceChangePercent { get; set; }
    }
}
