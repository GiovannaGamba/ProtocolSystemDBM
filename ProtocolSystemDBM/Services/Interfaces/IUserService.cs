using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserById(Guid userId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);
    }
}
