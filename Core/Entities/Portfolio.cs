using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public ICollection<UserPortfolio> UserPortfolios { get; set; }
    }
}
