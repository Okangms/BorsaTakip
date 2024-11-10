using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserPortfolio
    {
        public int Portfolio_id { get; set; }
        public int User_id { get; set; }
        public int Crypto_id { get; set; }
        public int Amount { get; set; }

        public Users Users { get; set; }
        public CryptoAsset CryptoAsset { get; set; }

    }
}
