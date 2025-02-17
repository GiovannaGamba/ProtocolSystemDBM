using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Repositories.Interfaces;
using ProtocolSystemDBM.Services.Interfaces;

namespace ProtocolSystemDBM.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task CreateUserAsync(User user)
        {
            User existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("Erro ao cadastrar usuário. Já existe um usuário com esse email");
            }

            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            User updatingUser = await GetUserById(user.Id);
            updatingUser.Update(user);
            await _userRepository.UpdateUserAsync(updatingUser);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            User deletingUser = await GetUserById(userId);
            await _userRepository.DeleteUserAsync(deletingUser);
        }
    }
}
