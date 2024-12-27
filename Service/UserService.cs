// Service/UserService.cs
using Core.Entities;
using Core.Services;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly CryptoDbContext _context;

        public UserService(CryptoDbContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return user;
        }

        public async Task RegisterAsync(User user, string password)
        {
            if (await IsEmailTakenAsync(user.Email))
                throw new System.Exception("Email is already taken");

            user.PasswordHash = HashPassword(password);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
