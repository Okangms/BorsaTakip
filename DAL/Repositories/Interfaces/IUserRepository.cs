// DAL/Repositories/Interfaces/IUserRepository.cs
using Core.Entities;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task<bool> IsEmailTakenAsync(string email);
    }
}
