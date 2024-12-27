using Core.entities;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Şifre hash'i
        public string Role { get; set; } = "User"; // Kullanıcı rolü (Opsiyonel)

        public ICollection<Portfolio> Portfolios { get; set; }
    }
}