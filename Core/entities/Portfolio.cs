using Core.entities;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<PortfolioItem> Items { get; set; }
    }
}
