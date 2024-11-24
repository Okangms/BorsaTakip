using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<Portfolio> Portfolio { get; set; }
    }
}
