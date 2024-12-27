using Core.Entities;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string email, string password);
        Task RegisterAsync(User user, string password);
        Task<bool> IsEmailTakenAsync(string email);
    }
}
