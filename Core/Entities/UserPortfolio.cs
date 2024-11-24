using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserPortfolio
    {
        public int UpId { get; set; }
        public int PortfolioId { get; set; }
        public int Id { get; set; }
        public int Amount { get; set; }
        public virtual Coin Coin { get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}
