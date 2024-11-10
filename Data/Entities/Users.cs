using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Users
    {
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public ICollection<UserPortfolio> Portfolios { get; set; }
    }
}
