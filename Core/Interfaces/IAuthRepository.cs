using System.Threading.Tasks;
using Core.Entities;
using Core.Wrappers;

namespace Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Register(User user, string password);
        Task<AuthResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}