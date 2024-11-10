﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CryptoAsset
    {
        public int Crypto_id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }

        public ICollection<UserPortfolio> Portfolios { get; set; }
    }
}
